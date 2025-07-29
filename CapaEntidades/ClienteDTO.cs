using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//
namespace CapaEntidades
{
    public class ClienteDTO
    {
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public bool Activo { get; set; }

        public string NombreCompleto => $"{Nombre}{PrimerApellido}{SegundoApellido}"; //Concatena nombre y apellidos para uso en el ComboBox

    }
}
