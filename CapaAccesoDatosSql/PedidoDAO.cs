using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using CapaEntidades;


namespace CapaAccesoDatosSql
{
    public class PedidoDAO
    {
        //Método que verifica la existencia de un pedido en la BD
        public bool ExistePedido(int numeroPedido)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT COUNT (*) FROM Pedido WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", numeroPedido);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;

            }
        
        }

        //Método encabezado para consulta de pedidos
        public List<PedidoDTO> ObtenerTodosLosPedidos()
        {
            var lista = new List<PedidoDTO>();

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = @"
                    SELECT  p.Id,
                            p.FechaPedido,
                            p.Direccion,
                            c.Identificacion AS IdCliente,
                            c.Nombre         AS ClienteNombre,
                            c.PrimerApellido AS ClientePrimerApellido,
                            c.SegundoApellido AS ClienteSegundoApellido,
                            r.Identificacion AS IdRepartidor,
                            r.Nombre         AS RepartidorNombre,
                            r.PrimerApellido AS RepartidorPrimerApellido,
                            r.SegundoApellido AS RepartidorSegundoApellido
                    FROM Pedido p
                    INNER JOIN Cliente    c ON p.IdCliente    = c.Identificacion
                    INNER JOIN Repartidor r ON p.IdRepartidor = r.Identificacion
                    ORDER BY p.Id DESC;";

                using SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                using SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var cliente = new ClienteDTO
                    {
                        Identificacion = Convert.ToInt32(dr["IdCliente"]),
                        Nombre = dr["ClienteNombre"].ToString(),
                        PrimerApellido = dr["ClientePrimerApellido"].ToString(),
                        SegundoApellido = dr["ClienteSegundoApellido"].ToString(),
                    };

                    var repartidor = new RepartidorDTO
                    {
                        Identificacion = Convert.ToInt32(dr["IdRepartidor"]),
                        Nombre = dr["RepartidorNombre"].ToString(),
                        PrimerApellido = dr["RepartidorPrimerApellido"].ToString(),
                        SegundoApellido = dr["RepartidorSegundoApellido"].ToString(),
                    };

                    var pedido = new PedidoDTO
                    {
                        NumeroPedido = Convert.ToInt32(dr["Id"]),
                        FechaPedido = Convert.ToDateTime(dr["FechaPedido"]),
                        DireccionEntrega = dr["Direccion"].ToString(),
                        Cliente = cliente,
                        Repartidor = repartidor
                    };

                    lista.Add(pedido);
                }
            }

            return lista;
        }


        //Método para registrar un pedido
        public bool RegistrarPedido(PedidoDTO pedido, List<DetallePedidoDTO> detalles)
        {
            using SqlConnection conn = ConexionBD.ObtenerConexion();
            conn.Open();

            using SqlTransaction tx = conn.BeginTransaction();

            try
            {
                // 1) Insertar encabezado y obtener Id generado
                string sqlPedido = @"
                    INSERT INTO Pedido (FechaPedido, IdCliente, IdRepartidor, Direccion)
                    VALUES (@FechaPedido, @IdCliente, @IdRepartidor, @Direccion);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                int idPedido;
                using (SqlCommand cmd = new SqlCommand(sqlPedido, conn, tx))
                {
                    cmd.Parameters.AddWithValue("@FechaPedido", pedido.FechaPedido);
                    cmd.Parameters.AddWithValue("@IdCliente", pedido.Cliente.Identificacion);
                    cmd.Parameters.AddWithValue("@IdRepartidor", pedido.Repartidor.Identificacion);
                    cmd.Parameters.AddWithValue("@Direccion", pedido.DireccionEntrega);

                    idPedido = (int)cmd.ExecuteScalar();
                }

                // 2) Insertar detalle(s) + actualizar inventario
                string sqlDetalle = @"
                    INSERT INTO DetallePedido (Idpedido, Idarticulo, Cantidad, Monto)
                    VALUES (@IdPedido, @IdArticulo, @Cantidad, @Monto);";

                string sqlActualizarInv = @"
                    UPDATE Articulo
                    SET Inventario = Inventario - @Cantidad,
                        Activo = CASE WHEN Inventario - @Cantidad <= 0 THEN 0 ELSE Activo END
                    WHERE Id = @IdArticulo;";

                foreach (var d in detalles)
                {
                    if (d.Cantidad <= 0)
                        throw new InvalidOperationException("La cantidad debe ser mayor a cero.");

                    // Insertar detalle
                    using (SqlCommand cmdDet = new SqlCommand(sqlDetalle, conn, tx))
                    {
                        cmdDet.Parameters.AddWithValue("@IdPedido", idPedido);
                        cmdDet.Parameters.AddWithValue("@IdArticulo", d.IdArticulo); // asegúrate que DetallePedidoDTO tiene esta propiedad
                        cmdDet.Parameters.AddWithValue("@Cantidad", d.Cantidad);
                        cmdDet.Parameters.AddWithValue("@Monto", d.Monto);
                        cmdDet.ExecuteNonQuery();
                    }

                    // Actualizar inventario
                    using (SqlCommand cmdInv = new SqlCommand(sqlActualizarInv, conn, tx))
                    {
                        cmdInv.Parameters.AddWithValue("@IdArticulo", d.IdArticulo);
                        cmdInv.Parameters.AddWithValue("@Cantidad", d.Cantidad);
                        cmdInv.ExecuteNonQuery();
                    }
                }

                tx.Commit();
                return true;
            }
            catch
            {
                tx.Rollback();
                throw; // Para que tu UI capture el error real
            }
        }

        public List<PedidoDTO> ObtenerPedidosPorCliente(int identificacionCliente)
        {
            List<PedidoDTO> pedidos = new List<PedidoDTO>();

            using SqlConnection conn = ConexionBD.ObtenerConexion();
            {
                conn.Open();
                string query = @"SELECT * FROM Pedido WHERE IdCliente = @IdCliente";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdCliente", identificacionCliente);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PedidoDTO pedido = new PedidoDTO
                    {
                        NumeroPedido = Convert.ToInt32(reader["NumeroPedido"]),
                        FechaPedido = Convert.ToDateTime(reader["FechaPedido"]),
                        DireccionEntrega = reader["DireccionEntrega"].ToString(),
                        Cliente = new ClienteDAO().ObtenerClientePorId(Convert.ToInt32(reader["IdCliente"])),
                        Repartidor = new RepartidorDAO().ObtenerRepartidorPorId(Convert.ToInt32(reader["IdRepartidor"]))
                    };

                    pedidos.Add(pedido);
                }
            }

            return pedidos;
        }
        public PedidoDTO? ObtenerPedidoPorId(int numeroPedido)
        {
            PedidoDTO? pedido = null;

            using SqlConnection conn = ConexionBD.ObtenerConexion();
            conn.Open();

            string query = @"
                SELECT  p.Id,
                    p.FechaPedido,
                    p.Direccion,
                    c.Identificacion AS IdCliente,
                    c.Nombre         AS ClienteNombre,
                    c.PrimerApellido AS ClientePrimerApellido,
                    c.SegundoApellido AS ClienteSegundoApellido,
                    r.Identificacion AS IdRepartidor,
                    r.Nombre         AS RepartidorNombre,
                    r.PrimerApellido AS RepartidorPrimerApellido,
                    r.SegundoApellido AS RepartidorSegundoApellido
                FROM Pedido p
                INNER JOIN Cliente    c ON p.IdCliente    = c.Identificacion
                INNER JOIN Repartidor r ON p.IdRepartidor = r.Identificacion
                WHERE p.Id = @NumeroPedido";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@NumeroPedido", numeroPedido);

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                var cliente = new ClienteDAO().ObtenerClientePorId(Convert.ToInt32(dr["IdCliente"]));
                var repartidor = new RepartidorDAO().ObtenerRepartidorPorId(Convert.ToInt32(dr["IdRepartidor"]));

                pedido = new PedidoDTO
                {
                    NumeroPedido = Convert.ToInt32(dr["Id"]),
                    FechaPedido = Convert.ToDateTime(dr["FechaPedido"]),
                    DireccionEntrega = dr["Direccion"].ToString(),
                    Cliente = cliente,
                    Repartidor = repartidor
                };
            }

            return pedido;
        }




        //Método que devuelve el último pedido agregado y así agrega en el detalle 
        public int ObtenerUltimoIdPedido()

        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT ISNULL(MAX(Id), 0) FROM Pedido";
                SqlCommand cmd = new SqlCommand(query,conn);
                conn.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            
            
            }


        }
            



    }
}
