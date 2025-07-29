using CapaComunicaciones.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaComunicaciones
{
    public class PedidoRegistroDTO_Red
    {
        public int IdCliente { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Direccion { get; set; }
        public List<DetallePedidoDTO_Red> Detalles { get; set; }
    }
}
