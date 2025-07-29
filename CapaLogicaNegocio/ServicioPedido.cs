using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidades;
using CapaAccesoDatosSql;
/**
 * UNED IIC 2025
 * Proyecto I: Desarrollo de software para al empresa ENTREGAS S.A, para la administración de pedidos y entregas de artículos registrados en el sistema
 * Estudiante: Keneth Mendez Torres (kenethgmendez@uned.cr)
 * Fecha: semana del 9 al 15 de Junio de 2025
 */
namespace CapaLogicaNegocio
{
     public static class ServicioPedido
    {
        /// <summary>
        /// Registra un pedido completo con encabezado y múltiples detalles
        /// </summary>
        /// <param name="encabezado"> Objeto de tipo PedidoEnc con info general del pedido </param>
        /// <param name="detalles">Lista de objetos DetallePedido asociados el pedido </param>
        /// <param name="mensaje">Mensaje de éxito o error </param>
        /// <returns> true si se registró correctamente; false en caso de error </returns>
        
        public static bool RegistrarPedidoCompleto(PedidoDTO encabezado, List<DetallePedidoDTO> detalles, out string mensaje)
        {
            mensaje = "";

            //Manejo de excepcione desde la Capa Lógica de Negocio
            try
            {
                //Validación básica
                if (encabezado == null || detalles == null || detalles.Count == 0)
                {
                    mensaje = "Faltan datos del pedido o los detalles están vacíos.";
                    return false;
                }

                //Se agrega el encabezado y se valida si la operación fue éxitosa o no
                if (!RepositorioPedido.Agregar(encabezado, out mensaje))
                {
                    // No agrego un mensaje acá porque ya viene contenido según el escenario en el RegistroPedido
                    return false;
                }
                foreach(var detalle in detalles)
                {
                    bool v = detalle.NumeroPedido == encabezado.NumeroPedido; 
                    if(!RepositorioDetallePedido.Agregar(detalle, out mensaje))
                    {
                        return false;
                    }
                }

                mensaje = "Pedido registrado exitosamente";

                return true;


            }
            catch (Exception ex)
            { 
                mensaje = "Ha ocurrido un error inesperado al registrar el pedido: " + ex.Message;
                return false;
            }
        }
       

    }
    public static class GeneradorConsecutivo
    {
        private static int ultimoNumero = 1000; 

        public static int ObtenerSiguienteNumero()
        {
            return ++ultimoNumero;
        }
    }
}
