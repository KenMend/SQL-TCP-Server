using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using CapaEntidades;

namespace CapaAccesoDatosSql
{
    public class DetallePedidoDAO
    {
        public List<DetallePedidoDTO> ObtenerDetallesPorPedido(int idPedido)
        {
            var lista = new List<DetallePedidoDTO>();

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = @"
                    SELECT dp.Idpedido, dp.Idarticulo, dp.Cantidad, dp.Monto,
                           a.Nombre AS NombreArticulo, a.Valor, a.Inventario, a.Activo,
                           ta.Id AS IdTipo, ta.Nombre AS NombreTipo, ta.Descripcion AS DescripcionTipo
                    FROM DetallePedido dp
                    INNER JOIN Articulo a      ON dp.Idarticulo = a.Id
                    INNER JOIN TipoArticulo ta ON a.IdTipoArticulo = ta.Id
                    WHERE dp.Idpedido = @IdPedido";

                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdPedido", idPedido);
                conn.Open();

                using SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var tipo = new TipoArticuloDTO
                    {
                        Id = Convert.ToInt32(dr["IdTipo"]),
                        Nombre = dr["NombreTipo"].ToString(),
                        Descripcion = dr["DescripcionTipo"].ToString()
                    };

                    var articulo = new ArticuloDTO
                    {
                        Id = Convert.ToInt32(dr["Idarticulo"]),
                        Nombre = dr["NombreArticulo"].ToString(),
                        Valor = Convert.ToDouble(dr["Valor"]),
                        Inventario = Convert.ToInt32(dr["Inventario"]),
                        Activo = Convert.ToBoolean(dr["Activo"]),
                        TipoArticulo = tipo
                    };

                    var detalle = new DetallePedidoDTO
                    {
                        IdPedido = Convert.ToInt32(dr["Idpedido"]),
                        IdArticulo = Convert.ToInt32(dr["Idarticulo"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        Monto = Convert.ToDouble(dr["Monto"]),
                        Articulo = articulo
                    };

                    lista.Add(detalle);
                }
            }

            return lista;
        }
        public bool RegistrarDetalle(DetallePedidoDTO detalle)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string query = @"INSERT INTO DetallePedido (IdPedido, IdArticulo, Cantidad, Monto)
                               VALUES (@IdPedido, @IdArticulo, @Cantidad, @Monto)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdPedido", detalle.IdPedido);
                cmd.Parameters.AddWithValue("@IdArticulo", detalle.Articulo.Id);
                cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                cmd.Parameters.AddWithValue("@Monto", detalle.Monto);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;

            }

        }

    }


}
      

    