using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Entities_DTO
{
    public class LibrosDTO
    {
        public int idLibro { get; set; }
        public int idCategoria { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public System.DateTime FechaPublicacion { get; set; }
    }
}
