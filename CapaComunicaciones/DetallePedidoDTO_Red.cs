using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaComunicaciones.Contracts
{
    public class DetallePedidoDTO_Red
    {
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Monto { get; set; }
    }
}
