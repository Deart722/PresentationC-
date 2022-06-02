using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Entities_DTO
{
    public class LibrosConUnidadesDTO
    {
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public Nullable<int> UNIDADES { get; set; }
    }
}
