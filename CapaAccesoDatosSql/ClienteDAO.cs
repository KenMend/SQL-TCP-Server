using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using CapaEntidades;


namespace CapaAccesoDatosSql

{

    public class ClienteDAO
        
    {

        public ClienteDAO()
        { 
           
        }

        //Método para verificar la existencia del Cliente en la base de datos
        public bool ExisteCliente(int identificacion)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {

                string query = "SELECT COUNT (*) FROM Cliente WHERE Identificacion = @Identificacion";
                SqlCommand cmd = new SqlCommand (query, conn);
                cmd.Parameters.AddWithValue("@Identificacion", identificacion);
                conn.Open();
                int count = (int)cmd.ExecuteScalar ();
                return count > 0;
            
            }       
        
        }

        //Método para registrar un cliente
        public bool RegistrarCliente(ClienteDTO cliente)
        {
            if (ExisteCliente(cliente.Identificacion))
            {
                throw new InvalidOperationException("Ya existe un cliente con esa identificación.");
            
            }

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            { 
                string query = @"INSERT INTO Cliente
                               (Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Activo)
                               VALUES
                               (@Identificacion, @Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @Activo)";

                SqlCommand cmd = new SqlCommand (query, conn);
                cmd.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@PrimerApellido", cliente.PrimerApellido);
                cmd.Parameters.AddWithValue("@SegundoApellido", cliente.SegundoApellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Activo", cliente.Activo);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;

            }

        }

        public List<ClienteDTO> ObtenerTodosLosClientes()
        { 
            var lista = new List<ClienteDTO>();

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string query = @"SELECT Identificacion, Nombre, PrimerApellido, SegundoApellido,
                                FechaNacimiento, Activo FROM Cliente";
                using SqlCommand cmd = new SqlCommand (query, conn);
                conn.Open();

                using SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new ClienteDTO
                    {
                        Identificacion = Convert.ToInt32(dr["Identificacion"]),
                        Nombre = dr["Nombre"].ToString(),
                        PrimerApellido = dr["PrimerApellido"].ToString(),
                        SegundoApellido = dr["SegundoApellido"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                        Activo = Convert.ToBoolean(dr["Activo"])

                    });

                }

            }
            return lista;
        
        }

        public ClienteDTO ObtenerClientePorId(int identificacion)
        {
            ClienteDTO cliente = null;

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM Cliente WHERE Identificacion = @Identificacion";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Identificacion", identificacion);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cliente = new ClienteDTO
                    {
                        Identificacion = Convert.ToInt32(reader["Identificacion"]),
                        Nombre = reader["Nombre"].ToString(),
                        PrimerApellido = reader["PrimerApellido"].ToString(),
                        SegundoApellido = reader["SegundoApellido"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                        Activo = Convert.ToBoolean(reader["Activo"])
                    };
                }
            }

            return cliente;
        }


    }
}
