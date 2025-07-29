using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaComunicaciones.Contracts;

/**
 * UNED II Cuatrimestres 2025
 * Proyecti 2: Redes, Colecciones, Subprocesos, Sql Bases de Datos
 * Estudiante: Keneth Mendez Torres
 * Fecha: 27/7/2025
 * */


namespace AppCliente.Red
{
    public static class ClienteSession
    {
        public static ClienteDTO_Red Cliente { get; set; }
        public static ClienteSocket Socket { get; set; }

    }
}
