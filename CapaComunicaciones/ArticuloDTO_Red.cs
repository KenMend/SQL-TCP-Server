using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaComunicaciones.Contracts
{
    public class ArticuloDTO_Red
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoArticulo { get; set; }
        public decimal Valor { get; set; }
        public int Inventario { get; set; }
    }
}
