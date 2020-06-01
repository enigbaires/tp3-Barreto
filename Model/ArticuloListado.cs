using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ArticuloListado
    {
        public int id { get; set; }
        public String codigo { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }
        public String marca { get; set; }
        public String categoria { get; set; }
        public String imagen { get; set; }
        public String precio { get; set; }
    }
}
