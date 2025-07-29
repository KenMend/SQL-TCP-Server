using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * UNED IIC 2025
 * Proyecto I: Desarrollo de software para al empresa ENTREGAS S.A, para la administración de pedidos y entregas de artículos registrados en el sistema
 * Estudiante: Keneth Mendez Torres (kenethgmendez@uned.cr)
 * Fecha: semana del 9 al 15 de Junio de 2025
 */
namespace CapaEntidades
{
    //Definicion de Clase public TipoArticulo
    public class DetallePedidoDTO
    {
        public int IdPedido { get; set; }
        public int IdArticulo { get; set; }
        public ArticuloDTO? Articulo { get; set; } //Atributo de Tipo ArticuloDTO
        public int Cantidad { get; set; }
        public double Monto { get; set; } // Este monto incluye el 12% del envío del artículo

    }
}
