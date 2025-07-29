using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text.Json;
using CapaComunicaciones;
using CapaComunicaciones.Contracts;
using CapaEntidades;

/**
 * UNED II Cuatrimestres 2025
 * Proyecti 2: Redes, Colecciones, Subprocesos, Sql Bases de Datos
 * Estudiante: Keneth Mendez Torres
 * Fecha: 27/7/2025
 * */

namespace AppCliente.Red
{
    public class ClienteSocket : IDisposable
    {
        private TcpClient? _tcp;
        private NetworkStream? _stream;


        public bool Conectado => _tcp?.Connected ?? false;

        public async Task ConectarAsync(string host = "127.0.0.1", int port = 14100, CancellationToken ct = default)
        {
            _tcp = new TcpClient();
            await _tcp.ConnectAsync(host, port, ct);
            _stream = _tcp.GetStream();
        
        }

        public void Desconectar()
        {
            try
            {
                _stream?.Close();
                _tcp?.Close();

            
            }
            catch { }
        
        }


        public void Dispose() => Desconectar();

        // Helper genérico para enviar una request y recibir response

        private async Task<NetResponse?> SendAsync(OpCode op, object? payloadObj = null, CancellationToken ct = default)
        {
            if (_stream == null)
                throw new InvalidOperationException("No hay conexión con el Servidor.");

            var req = new NetRequest
            {
                Op = op,
                Payload = payloadObj == null ? null : NetProtocol.ToJson(payloadObj),

            };

            await NetProtocol.SendAsync(_stream, req, ct);
            var resp = await NetProtocol.ReceiveAsync<NetResponse>(_stream, ct);
            return resp;
        
        }
        //---------------------
        //Métodos de alto nivel
        //---------------------

        public async Task<LoginResponse?> LoginAsync(int identificacion, CancellationToken ct = default)
        {
            var resp = await SendAsync(OpCode.LoginCliente, new LoginRequest { Identificacion = identificacion }, ct);

            if (resp == null || !resp.Ok)
                throw new InvalidOperationException(resp?.Message ?? "Error desconocido en login.");

            return NetProtocol.FromJson<LoginResponse>(resp.Payload);
        
        }

        public async Task<List<ArticuloDTO_Red>> ObtenerArticulosActivosAsync(CancellationToken ct = default)
        {
            var resp = await SendAsync(OpCode.ObtenerArticulosActivos, null, ct);
            if (resp == null || !resp.Ok)
                throw new InvalidOperationException(resp?.Message ?? "Error consultando artículos.");

            return NetProtocol.FromJson<List<ArticuloDTO_Red>>(resp.Payload) ?? new();
        
        }

        public async Task<ArticuloDTO_Red?> ObtenerArticuloPorIdAsync(int idArticulo, CancellationToken ct = default)
        {
            var resp = await SendAsync(OpCode.ObtenerArticuloPorId, new ArticuloByIdRequest { IdArticulo = idArticulo }, ct);
            if (resp == null || !resp.Ok)
                throw new InvalidOperationException(resp?.Message ?? "Error consultando artículo.");

            return NetProtocol.FromJson<ArticuloDTO_Red>(resp.Payload);
        }

        public async Task RegistrarPedidoAsync(RegistrarPedidoRequest request, CancellationToken ct = default)
        {
            var resp = await SendAsync(OpCode.RegistrarPedido, request, ct);
            if (resp == null || !resp.Ok)
                throw new InvalidOperationException(resp?.Message ?? "No se pudo registrar el pedido");
        }

        public async Task<List<PedidoDTO_Red>> ConsultarMisPedidosAsync(CancellationToken ct = default)
        {
            var resp = await SendAsync(OpCode.ConsultarMisPedidos, null, ct);
            if (resp == null || !resp.Ok)
                throw new InvalidOperationException(resp?.Message ?? "Error consultando pedidos del cliente.");

            return NetProtocol.FromJson<List<PedidoDTO_Red>>(resp.Payload) ?? new();
        }

        public async Task<PedidoConDetallesResponse_Red?> ConsultarPedidoPorIdAsync(int numeroPedido, CancellationToken ct = default)
        {
            var resp = await SendAsync(OpCode.ConsultarPedidoPorId, new PedidoByIdRequest { NumeroPedido = numeroPedido }, ct);
            if (resp == null || !resp.Ok)
                throw new InvalidOperationException(resp?.Message ?? "Error consultando pedido por Id.");

            return NetProtocol.FromJson<PedidoConDetallesResponse_Red>(resp.Payload);
        }
        public async Task<LoginResponse?> LoginAsync(LoginRequest request, CancellationToken ct = default)
        {
            return await LoginAsync(request.Identificacion, ct);
        }

    }
}
