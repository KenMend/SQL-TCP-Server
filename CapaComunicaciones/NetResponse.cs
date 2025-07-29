using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaComunicaciones
{
    public class NetResponse
    {
        public bool Ok { get; set; }
        public string? Message { get; set; }

        public string? Payload { get; set; }

    }
}
