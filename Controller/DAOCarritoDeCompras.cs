using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class DAOCarritoDeCompras : DAOMaster
    {
        public CarritoDeCompras AddItem(ArticuloListado item)
        {
            CarritoDeCompras result = new CarritoDeCompras();
            result.id = item.id;
            result.codigo = item.codigo;
            result.nombre = item.nombre;
            result.imagen = item.imagen;
            result.marca = item.marca;
            result.cantidad = 1;
            result.precioUnitario = Convert.ToDecimal(item.precio.Substring(2));
            return result;
        }
    }
}
