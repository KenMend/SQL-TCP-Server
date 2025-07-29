using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidades;// Que permite el uso de los elementos de la Capa de Entidades
/**
 * UNED IIC 2025
 * Proyecto I: Desarrollo de software requerido por la empresa ENTREGAS S.A, para la administración de pedidos y entregas de artículos registrados en el sistema.
 * Estudiante: Keneth Mendez Torres (kenethgmendez@uned.cr)
 * Fecha: semana del 9 al 15 de Junio de 2025
 */
namespace CapaAccesoDatos
{
    //Manejo el almacenamiento y consulta de clientes.
    public static class RepositorioRepartidor
    {
   

        //Método para calcular la edad en base a la fecha de nacimiento
        //este método verifica la edad en años completos y luego revisa si aunque los años cumplidos sean suficientes para
        //ser mayor, el mes del año actual cumpla ese requisito también
        private static int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime hoy = DateTime.Today;
            int edad = hoy.Year - fechaNacimiento.Year;
            if(fechaNacimiento > hoy.AddYears(-edad))
            {
                edad--;
            }
            return edad;
        }


    }

}
