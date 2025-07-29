using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
/**
 * UNED IIC 2025
 * Proyecto I: Desarrollo de software para al empresa ENTREGAS S.A, para la administración de pedidos y entregas de artículos registrados en el sistema
 * Estudiante: Keneth Mendez Torres (kenethgmendez@uned.cr)
 * Fecha: semana del 9 al 15 de Junio de 2025
 */
namespace CapaEntidades
{
    //Definicion de Clase public PedidoEnc, hará la función de encabezado cuando así sea requerido
    public class PedidoDTO
    {
        public int NumeroPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public ClienteDTO? Cliente { get; set; }
        //Objeto tipo Cliente
        public RepartidorDTO? Repartidor { get; set; }
        //Objeto tipo Repartidor
        public string? DireccionEntrega { get; set; }


    }
}
