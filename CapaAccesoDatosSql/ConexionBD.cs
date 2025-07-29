using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace CapaAccesoDatosSql
{
    public static class ConexionBD
    {
        public static SqlConnection ObtenerConexion()
        { 
            string cadena = ConfigurationManager.ConnectionStrings["ConexionSql"].ConnectionString;
            return new SqlConnection(cadena);
        }

    }
}
