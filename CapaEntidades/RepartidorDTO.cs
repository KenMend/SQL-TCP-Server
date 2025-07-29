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
    public class RepartidorDTO 
    {

        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaContratacion { get; set; }
        public bool Activo { get; set; }

        public string NombreCompleto => $"{Nombre}{PrimerApellido}{SegundoApellido}"; //Concatena nombre y apellidos para uso en el ComboBox
    }
}
