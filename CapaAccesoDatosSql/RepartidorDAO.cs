using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using CapaEntidades;

namespace CapaAccesoDatosSql
{
    public class RepartidorDAO
    {
        //Método para verificar la existencia del Repartidor en la base de datos
        public bool ExisteRepartidor(int identificacion)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT COUNT (*) FROM Repartidor WHERE Identificacion = @Identificacion";
                using SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Identificacion", identificacion);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;

            }
        
        }
        //Método para registrar un repartidor, y sus respectivas validaciones
        public bool RegistrarRepartidor(RepartidorDTO repartidor)
        {
            if (ExisteRepartidor(repartidor.Identificacion))
                throw new InvalidOperationException("Ya existe un repartidor con esa identificación.");

            //Validaciones de Edad y Fecha de contratación
            if (CalcularEdad(repartidor.FechaNacimiento) < 18)
                throw new InvalidOperationException("El repartidor debe ser mayor de edad.");

            if (repartidor.FechaContratacion.Date > DateTime.Today)
                throw new InvalidOperationException("La Fecha de contratación no puede ser mayor que la fecha actual.");


            //Inserción de Datos a Sql
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            { 
                string query = @"
                      INSERT INTO Repartidor
                      (Identificacion, Nombre, PrimerApellido, SegundoApellido,FechaNacimiento, FechaContratacion, Activo)
                      VALUES
                      (@Identificacion, @Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @FechaContratacion, @Activo)";
                using SqlCommand cmd = new SqlCommand (query, conn);    
                cmd.Parameters.AddWithValue("@Identificacion", repartidor.Identificacion);
                cmd.Parameters.AddWithValue("@Nombre", repartidor.Nombre);
                cmd.Parameters.AddWithValue("@PrimerApellido", repartidor.PrimerApellido);
                cmd.Parameters.AddWithValue("@SegundoApellido", repartidor.SegundoApellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", repartidor.FechaNacimiento);
                cmd.Parameters.AddWithValue("@FechaContratacion", repartidor.FechaContratacion);
                cmd.Parameters.AddWithValue("@Activo", repartidor.Activo);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;


            }
        
        }
        public List<RepartidorDTO> ObtenerTodosLosRepartidores()
        {
            var lista = new List<RepartidorDTO>();

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                string query = @"SELECT Identificacion, Nombre, PrimerApellido, SegundoApellido,
                               FechaNacimiento, FechaContratacion, Activo FROM Repartidor";

                using SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();


                using SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new RepartidorDTO
                    {
                        Identificacion = Convert.ToInt32(dr["Identificacion"]),
                        Nombre = dr["Nombre"].ToString(),
                        PrimerApellido = dr["PrimerApellido"].ToString(),
                        SegundoApellido = dr["SegundoApellido"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                        FechaContratacion = Convert.ToDateTime(dr["FechaContratacion"]),
                        Activo = Convert.ToBoolean(dr["Activo"])

                    });
                }

            }
            return lista;


        }

        public RepartidorDTO ObtenerRepartidorPorId(int identificacion)
        {
            RepartidorDTO repartidor = null;

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM Repartidor WHERE Identificacion = @Identificacion";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Identificacion", identificacion);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    repartidor = new RepartidorDTO
                    {
                        Identificacion = Convert.ToInt32(reader["Identificacion"]),
                        Nombre = reader["Nombre"].ToString(),
                        PrimerApellido = reader["PrimerApellido"].ToString(),
                        SegundoApellido = reader["SegundoApellido"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                        FechaContratacion = Convert.ToDateTime(reader["FechaContratacion"]),
                        Activo = Convert.ToBoolean(reader["Activo"])
                    };
                }
            }

            return repartidor;
        }

        //Método para calcular la edad y así validar si la edad del repartidor > 18 años (Helper)
        private int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime hoy = DateTime.Today;
            int edad = hoy.Year - fechaNacimiento.Year; //Calcula la edad en años
            if (fechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
            return edad;
        }
    }
}
