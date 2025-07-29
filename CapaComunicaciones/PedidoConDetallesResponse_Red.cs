using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaComunicaciones.Contracts
{
    public class PedidoConDetallesResponse_Red
    {
        public PedidoDTO_Red Encabezado { get; set; } = new ();
        public List<DetallePedidoDTO_Red> Detalles { get; set; } = new();
    }
    public class PedidoDTO_Red
    {
        public int NumeroPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public string? DireccionEntrega { get; set; }
    }


}
