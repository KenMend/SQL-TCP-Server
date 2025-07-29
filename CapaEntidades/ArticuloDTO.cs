using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * UNED IIC 2025
 * Proyecto II: Desarrollo de software para al empresa ENTREGAS S.A, para la administración de pedidos y entregas de artículos registrados en el sistema
 * Estudiante: Keneth Mendez Torres (kenethgmendez@uned.cr)
 * Fecha: semana del 21 al 27 de Julio de 2025
 */

namespace CapaEntidades
{
    //Definicion de Clase public Articulo.
    public class ArticuloDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdTipoArticulo { get; set; }
        public TipoArticuloDTO TipoArticulo {get; set;}// relación con TipoArticulo
        public double Valor { get; set; }
        public int Inventario { get; set; }
        public bool Activo { get; set; }

    }
}
