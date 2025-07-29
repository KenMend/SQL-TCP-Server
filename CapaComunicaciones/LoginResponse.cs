using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaComunicaciones.Contracts
{
    public class LoginResponse
    {
        public int Identificacion { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public bool Ok { get; set; }

        public string Message { get; set; } = string.Empty;
        public ClienteDTO_Red Cliente { get; set; } = new();

    }
}
