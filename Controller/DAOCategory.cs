using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class DAOCategory : DAOMaster
    {
        public String SearchCategory(int idCategory)
        {
            String result = "Category not found";
            String commandText = "select Descripcion from CATEGORIAS where Id = " + idCategory;
            String description = SearchString("SearchCategory", commandText);
            result = description;
            return result;
        }
    }
}
