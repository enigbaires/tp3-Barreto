using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Articulo
    {
        public int id { get; set; }
        public String codigo { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }
        public int marca { get; set; }
        public int categoria { get; set; }
        public String imagen { get; set; }
        public decimal precio { get; set; }

    }
}
