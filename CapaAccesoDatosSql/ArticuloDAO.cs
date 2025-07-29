using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using CapaEntidades;

namespace CapaAccesoDatosSql
{
    public class ArticuloDAO
    {
        //Método que muestra los articulos
        public List<ArticuloDTO> ObtenerTodosLosArticulos()
        {
            var lista = new List<ArticuloDTO>();

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string sql = @"SELECT  a.Id, a.Nombre, a.IdTipoArticulo, a.Valor, a.Inventario, a.Activo,
                               t.Id       AS TipoId,
                               t.Nombre   AS TipoNombre,
                               t.Descripcion AS TipoDescripcion
                       FROM Articulo a
                       INNER JOIN TipoArticulo t ON t.Id = a.IdTipoArticulo";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                using SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var tipo = new TipoArticuloDTO
                    {
                        Id = Convert.ToInt32(dr["TipoId"]),
                        Nombre = dr["TipoNombre"].ToString(),
                        Descripcion = dr["TipoDescripcion"].ToString()
                    };

                    lista.Add(new ArticuloDTO
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Nombre = dr["Nombre"].ToString(),
                        IdTipoArticulo = Convert.ToInt32(dr["IdTipoArticulo"]),
                        Valor = Convert.ToDouble(dr["Valor"]),
                        Inventario = Convert.ToInt32(dr["Inventario"]),
                        Activo = Convert.ToBoolean(dr["Activo"]),
                        TipoArticulo = tipo
                    });
                }
            }

            return lista;
        }



        //Método para verificar que el ID del Artículo no exista ya en la BD
        public bool ExisteArticulo(int id)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT COUNT (*) FROM Articulo WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            
            }
        
        }

        //Método para registrar un artículo en la BD
        public bool RegistrarArticulo(ArticuloDTO articulo)
        {
            if (ExisteArticulo(articulo.Id))
            {
                throw new InvalidOperationException("Ya existe un artículo con ese ID.");
            
            }

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string query = @"INSERT INTO Articulo(Id, Nombre, IdTipoArticulo, Valor, Inventario, Activo)
                               VALUES(@Id, @Nombre, @IdTipoArticulo, @Valor, @Inventario, @Activo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", articulo.Id);
                cmd.Parameters.AddWithValue("@Nombre", articulo.Nombre);
                cmd.Parameters.AddWithValue("@IdTipoArticulo", articulo.TipoArticulo.Id);
                cmd.Parameters.AddWithValue("@Valor", articulo.Valor);
                cmd.Parameters.AddWithValue("@Inventario", articulo.Inventario);
                cmd.Parameters.AddWithValue("@Activo", articulo.Activo);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;

            }
        
        }
        public ArticuloDTO ObtenerArticuloPorId(int idArticulo)
        {
            ArticuloDTO articulo = null;

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"SELECT a.Id, a.Nombre, a.Inventario, a.Activo, ta.Id AS TipoId, ta.Nombre AS TipoNombre, ta.Descripcion
                         FROM Articulo a
                         INNER JOIN TipoArticulo ta ON a.IdTipoArticulo = ta.Id
                         WHERE a.Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", idArticulo);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    articulo = new ArticuloDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Inventario = Convert.ToInt32(reader["Inventario"]),
                        Activo = Convert.ToBoolean(reader["Activo"]),
                        TipoArticulo = new TipoArticuloDTO
                        {
                            Id = Convert.ToInt32(reader["TipoId"]),
                            Nombre = reader["TipoNombre"].ToString(),
                            Descripcion = reader["Descripcion"].ToString()
                        }
                    };
                }
            }

            return articulo;
        }



        //Método para obtener los Tipos de Artículos y así llenar el ComboBox para seleccionarlos
        public DataTable ObtenerTiposArticulo()
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT Id, Nombre FROM TipoArticulo WHERE 1=1";
                SqlCommand cmd = new SqlCommand (query, conn);
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            
            }
        
        }
    }
}
