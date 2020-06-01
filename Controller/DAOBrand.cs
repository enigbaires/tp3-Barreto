using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class DAOBrand : DAOMaster
    {
        public String SearchBrand(int idBrand)
        {
            String result = "Category not found";
            String commandText = "select Descripcion from MARCAS where Id = " + idBrand;
            String description = SearchString("SearchBrand", commandText);
            result = description;
            return result;
        }
    }
}
