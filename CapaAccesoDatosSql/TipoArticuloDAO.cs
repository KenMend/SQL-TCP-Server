using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using Microsoft.Data.SqlClient;

namespace CapaAccesoDatosSql
{
    public class TipoArticuloDAO
    {
        //Método para verificar que el ID del TipoArtículo no exista ya
        public bool ExisteTipoArticulo(int id)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT COUNT(*) FROM TipoArticulo WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;

            }

        }

        //Método para registrar un tipo de artículo
        public bool RegistrarTipoArticulo(TipoArticuloDTO tipo)
        {
            if (ExisteTipoArticulo(tipo.Id))
            {

                throw new InvalidOperationException("Ya existe un tipo de artículo con ese ID,");
            
            }

            using (var conn = ConexionBD.ObtenerConexion())
            {
                string query = @"INSERT INTO TipoArticulo (Id, Nombre, Descripcion)
                               VALUES (@Id, @Nombre, @Descripcion)";
                SqlCommand cmd = new SqlCommand (query, conn);
                cmd.Parameters.AddWithValue("@Id", tipo.Id);
                cmd.Parameters.AddWithValue("@Nombre", tipo.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", tipo.Descripcion);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;

            }

        }

        //Método para Consultar los tipos de artículos
        public List<TipoArticuloDTO> ObtenerTodosLosTipos()
        { 
            List<TipoArticuloDTO> tipos = new List<TipoArticuloDTO> ();

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT Id, Nombre, Descripcion FROM TipoArticulo";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tipos.Add(new TipoArticuloDTO
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"].ToString()
                        });
                    }
                }
            }
            return tipos;
        
        }

    }
}
