using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaComunicaciones.Contracts
{
    public class RegistrarPedidoRequest
    {
        public DateTime FechaPedido { get; set; }
        public int IdRepartidor { get; set; }
        public string Direccion { get; set; } = string.Empty;

        public List<RegistrarDetalleRequest> Detalles { get; set; } = new();

    }

    public class RegistrarDetalleRequest
    {
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public double Monto { get; set; }
    }
}
