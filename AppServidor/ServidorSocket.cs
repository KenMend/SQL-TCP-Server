using CapaAccesoDatosSql;
using CapaComunicaciones;
using CapaComunicaciones.Contracts;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
/**
 * UNED II Cuatrimestres 2025
 * Proyecti 2: Redes, Colecciones, Subprocesos, Sql Bases de Datos
 * Estudiante: Keneth Mendez Torres
 * Fecha: 27/7/2025
 * */
namespace AppServidor.Red
{
    public class ServidorSocket
    {
        private readonly TcpListener _listener;
        private readonly List<ClientHandler> _clients = new();
        private readonly object _sync = new();

        private CancellationTokenSource? _cts;

        public event Action<string>? OnLog;
        public event Action<int>? OnClientesConectadosChanged;

        public ServidorSocket(string host = "127.0.0.1", int port = 14100)
        {
            _listener = new TcpListener(IPAddress.Parse(host), port);
        }

        public void Start()
        {
            _cts = new CancellationTokenSource();
            _listener.Start();
            Log("Servidor escuchando en 127.0.0.1:14100");
            _ = AcceptLoopAsync(_cts.Token);
        }

        public void Stop()
        {
            try
            {
                _cts?.Cancel();
                lock (_sync)
                {
                    foreach (var c in _clients.ToList())
                        c.Close();
                    _clients.Clear();
                }
                _listener.Stop();
                Log("Servidor detenido.");
                //OnClientesConectadosChanged?.Invoke(0);
            }
            catch (Exception ex)
            {
                Log($"Error al detener: {ex.Message}");
            }
        }

        private async Task AcceptLoopAsync(CancellationToken ct)
        {
            try
            {
                while (!ct.IsCancellationRequested)
                {
                    var tcpClient = await _listener.AcceptTcpClientAsync(ct);

                    lock (_sync)
                    {
                        if (_clients.Count >= 5)
                        {
                            Log("Conexión rechazada: máximo 5 clientes.");
                            tcpClient.Close();
                            continue;
                        }
                    }

                    var handler = new ClientHandler(tcpClient, this, ct);
                    lock (_sync)
                    {
                        _clients.Add(handler);
                        OnClientesConectadosChanged?.Invoke(_clients.Count);
                    }
                    Log($"Cliente conectado: {tcpClient.Client.RemoteEndPoint}");
                    handler.Start();
                }
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                Log($"AcceptLoop error: {ex.Message}");
            }
        }
        private void RemoveClient(ClientHandler client)
        {
            lock (_sync)
            {
                _clients.Remove(client);
                OnClientesConectadosChanged?.Invoke(_clients.Count);
            }
            Log("Cliente desconectado.");
        }

        private void Log(string msg) => OnLog?.Invoke($"[{DateTime.Now:HH:mm:ss}] {msg}");

        private class ClientHandler
        {
            private readonly TcpClient _client;
            private readonly ServidorSocket _server;
            private readonly CancellationToken _ct;
            private readonly NetworkStream _stream;

            // DAOs
            private readonly ClienteDAO _clienteDao = new();
            private readonly ArticuloDAO _articuloDao = new();
            private readonly PedidoDAO _pedidoDao = new();
            private readonly DetallePedidoDAO _detalleDao = new();

            // Estado del cliente autenticado
            private ClienteDTO? _clienteActual;

            public ClientHandler(TcpClient client, ServidorSocket server, CancellationToken ct)
            {
                _client = client;
                _server = server;
                _ct = ct;
                _stream = _client.GetStream();
            }

            public void Start() => _ = RunAsync();

            public void Close()
            {
                try
                {
                    _stream.Close();
                    _client.Close();
                }
                catch { }
            }
            private async Task RunAsync()
            {
                try
                {
                    while (!_ct.IsCancellationRequested && _client.Connected)
                    {
                        var req = await NetProtocol.ReceiveAsync<NetRequest>(_stream, _ct);
                        if (req == null) break;

                        await ProcesarAsync(req);
                    }
                }
                catch (OperationCanceledException) { }
                catch (Exception ex)
                {
                    _server.Log($"Error con el cliente {_client.Client.RemoteEndPoint}: {ex.Message}");
                }
                finally
                {
                    Close();
                    _server.RemoveClient(this);
                }


            }
            private async Task ProcesarAsync(NetRequest req)
            {
                switch (req.Op)
                {
                    case OpCode.Ping:
                        await NetProtocol.SendAsync(_stream, new NetResponse { Ok = true, Message = "PONG" }, _ct);
                        break;

                    case OpCode.LoginCliente:
                        await AtenderLogin(req.Payload);
                        break;

                    case OpCode.ObtenerArticulosActivos:
                        await AtenderObtenerArticulosActivos();
                        break;

                    case OpCode.ObtenerArticuloPorId:
                        await AtenderObtenerArticuloPorId(req.Payload);
                        break;

                    case OpCode.RegistrarPedido:
                        await AtenderRegistrarPedido(req.Payload);
                        break;

                    case OpCode.ConsultarMisPedidos:
                        await AtenderConsultarMisPedidos();
                        break;

                    case OpCode.ConsultarPedidoPorId:
                        await AtenderConsultarPedidoPorId(req.Payload);
                        break;

                    default:
                        await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = "Operación no soportada" }, _ct);
                        break;

                }

            }

            private async Task AtenderLogin(string? payload)
            {
                try
                {
                    var dto = NetProtocol.FromJson<LoginRequest>(payload);
                    if (dto == null)
                    {
                        await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = "Payload inválido" }, _ct);
                        return;
                    }

                    // ------- Llama a tu DAO --------
                    var cliente = _clienteDao.ObtenerClientePorId(dto.Identificacion); // Implementa esto si no lo tienes
                    if (cliente == null || !cliente.Activo)
                    {
                        await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = "Cliente no existe o está inactivo." }, _ct);
                        return;

                    }
                    _clienteActual = cliente;
                    _server.Log($"Login: {cliente.Identificacion} - {cliente.Nombre} {cliente.PrimerApellido} {cliente.SegundoApellido}");

                    var resp = new LoginResponse
                    {
                        Identificacion = cliente.Identificacion,
                        NombreCompleto = $"{cliente.Nombre} {cliente.PrimerApellido} {cliente.SegundoApellido}"
                    };
                    await NetProtocol.SendAsync(_stream, new NetResponse
                    {
                        Ok = true,
                        Message = "Login OK",
                        Payload = NetProtocol.ToJson(resp)
                    }, _ct);

                }
                catch (Exception ex)
                {
                    await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = ex.Message }, _ct);
                }


            }
            private async Task AtenderObtenerArticulosActivos()
            {
                try
                {
                    // ------- DAO -------
                    var lista = _articuloDao.ObtenerTodosLosArticulos()
                                            .Where(a => a.Activo && a.Inventario > 0)
                                            .ToList();

                    // Mapea a DTO_Red si no quieres enviar CapaEntidades directo
                    var result = lista.Select(a => new ArticuloDTO_Red
                    {
                        Id = a.Id,
                        Nombre = a.Nombre,
                        IdTipoArticulo = a.IdTipoArticulo,
                        Valor = a.Valor,
                        Inventario = a.Inventario,
                        Activo = a.Activo,
                        TipoArticuloNombre = a.TipoArticulo?.Nombre // si lo tienes
                    }).ToList();

                    await NetProtocol.SendAsync(_stream, new NetResponse
                    {
                        Ok = true,
                        Payload = NetProtocol.ToJson(result)
                    }, _ct);
                }
                catch (Exception ex)
                {
                    await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = ex.Message }, _ct);
                }
            }
            private async Task AtenderObtenerArticuloPorId(string? payload)
            {
                try
                {
                    var req = NetProtocol.FromJson<ArticuloByIdRequest>(payload);
                    if (req == null)
                    {
                        await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = "Payload inválido" }, _ct);
                        return;
                    }

                    var art = _articuloDao.ObtenerArticuloPorId(req.IdArticulo); // implementa en tu DAO
                    if (art == null)
                    {
                        await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = "Artículo no existe" }, _ct);
                        return;
                    }

                    var dto = new ArticuloDTO_Red
                    {
                        Id = art.Id,
                        Nombre = art.Nombre,
                        IdTipoArticulo = art.IdTipoArticulo,
                        Valor = art.Valor,
                        Inventario = art.Inventario,
                        Activo = art.Activo,
                        TipoArticuloNombre = art.TipoArticulo?.Nombre
                    };

                    await NetProtocol.SendAsync(_stream, new NetResponse
                    {
                        Ok = true,
                        Payload = NetProtocol.ToJson(dto)
                    }, _ct);
                }
                catch (Exception ex)
                {
                    await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = ex.Message }, _ct);
                }
            }
            private async Task AtenderRegistrarPedido(string? payload)
            {
                try
                {
                    if (_clienteActual == null)
                    {
                        await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = "No está logueado." }, _ct);
                        return;
                    }

                    var req = NetProtocol.FromJson<RegistrarPedidoRequest>(payload);
                    if (req == null)
                    {
                        await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = "Payload inválido" }, _ct);
                        return;
                    }

                    // Mapea a tus DTO reales
                    var pedido = new PedidoDTO
                    {
                        FechaPedido = req.FechaPedido,
                        Cliente = _clienteActual,
                        Repartidor = new RepartidorDTO { Identificacion = req.IdRepartidor }, // Valídalo si querés
                        DireccionEntrega = req.Direccion
                    };

                    var detalles = req.Detalles.Select(d => new DetallePedidoDTO
                    {
                        IdArticulo = d.IdArticulo,
                        Cantidad = d.Cantidad,
                        Monto = d.Monto
                    }).ToList();

                    bool ok = _pedidoDao.RegistrarPedido(pedido, detalles); // tu método actual
                    if (ok)
                    {
                        _server.Log($"Pedido registrado por cliente {_clienteActual.Identificacion}");
                        await NetProtocol.SendAsync(_stream, new NetResponse { Ok = true, Message = "Pedido registrado." }, _ct);
                    }
                    else
                    {
                        await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = "No se pudo registrar" }, _ct);
                    }
                }
                catch (Exception ex)
                {
                    await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = ex.Message }, _ct);
                }
            }
            private async Task AtenderConsultarMisPedidos()
            {
                try
                {
                    if (_clienteActual == null)
                    {
                        await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = "No está logueado." }, _ct);
                        return;
                    }

                    var pedidos = _pedidoDao.ObtenerPedidosPorCliente(_clienteActual.Identificacion); // implementa
                    
                    var result = pedidos.Select(p => new PedidoDTO_Red
                    {
                        NumeroPedido = p.NumeroPedido,
                        FechaPedido = p.FechaPedido,
                        DireccionEntrega = p.DireccionEntrega
                    }).ToList();

                    await NetProtocol.SendAsync(_stream, new NetResponse
                    {
                        Ok = true,
                        Payload = NetProtocol.ToJson(result)
                    }, _ct);
                }
                catch (Exception ex)
                {
                    await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = ex.Message }, _ct);
                }
            }
            private async Task AtenderConsultarPedidoPorId(string? payload)
            {
                try
                {
                    if (_clienteActual == null)
                    {
                        await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = "No está logueado." }, _ct);
                        return;
                    }

                    var req = NetProtocol.FromJson<PedidoByIdRequest>(payload);
                    if (req == null)
                    {
                        await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = "Payload inválido" }, _ct);
                        return;
                    }

                    var pedido = _pedidoDao.ObtenerPedidoPorId(req.NumeroPedido); // implementa
                    if (pedido == null || pedido.Cliente.Identificacion != _clienteActual.Identificacion)
                    {
                        await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = "Pedido no existe o no es del cliente" }, _ct);
                        return;
                    }

                    var detalles = _detalleDao.ObtenerDetallesPorPedido(req.NumeroPedido);

                    var resp = new PedidoConDetallesResponse_Red
                    {
                        Encabezado = new PedidoDTO_Red
                        {
                            NumeroPedido = pedido.NumeroPedido,
                            FechaPedido = pedido.FechaPedido,
                            DireccionEntrega = pedido.DireccionEntrega
                        },
                        Detalles = detalles.Select(d => new DetallePedidoDTO_Red
                        {
                            IdArticulo = d.IdArticulo,
                            Cantidad = d.Cantidad,
                            Monto = d.Monto
                        }).ToList()
                    };

                    await NetProtocol.SendAsync(_stream, new NetResponse
                    {
                        Ok = true,
                        Payload = NetProtocol.ToJson(resp)
                    }, _ct);
                }
                catch (Exception ex)
                {
                    await NetProtocol.SendAsync(_stream, new NetResponse { Ok = false, Message = ex.Message }, _ct);
                }
            }

        }

    }
    public class ArticuloDTO_Red
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int IdTipoArticulo { get; set; }
        public double Valor { get; set; }
        public int Inventario { get; set; }
        public bool Activo { get; set; }
        public string? TipoArticuloNombre { get; set; }
    }
    public class PedidoDTO_Red
    {
        public int NumeroPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public string? DireccionEntrega { get; set; }
    }
    public class DetallePedidoDTO_Red
    {
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public double Monto { get; set; }
    }

    public class PedidoConDetallesResponse_Red
    {
        public PedidoDTO_Red Encabezado { get; set; } = new();
        public List<DetallePedidoDTO_Red> Detalles { get; set; } = new();
    }



}
