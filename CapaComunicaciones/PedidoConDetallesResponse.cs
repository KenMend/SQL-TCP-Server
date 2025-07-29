using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaComunicaciones.Contracts
{
    public class PedidoConDetallesResponse
    {
        //public PedidoDTO Encabezado { get; set; }
   
        public List<DetallePedidoVisual_Red> Detalles { get; set; }


    }
}
