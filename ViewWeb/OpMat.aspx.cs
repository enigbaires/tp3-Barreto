using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Controller;

namespace ViewWeb
{
    public partial class OpMat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["id"] == null || Request.QueryString["op"] == null || Session[Session.SessionID + "shoppingCartList"] == null) Response.Redirect("~/");

            List<CarritoDeCompras> shoppingCartList = (List<CarritoDeCompras>)Session[Session.SessionID + "shoppingCartList"];
            int idItemSelected = Convert.ToInt32(Request.QueryString["id"]);
            String op = Request.QueryString["op"];
            CarritoDeCompras itemListSelected = shoppingCartList.Find(J => J.id == idItemSelected);
            DAOCarritoDeCompras dAOCarritoDeCompras = new DAOCarritoDeCompras();
            int qtyAux = itemListSelected.cantidad;
            int result = qtyAux;

            if (op=="minus")
            {
                if (qtyAux > 1)
                {
                    result = qtyAux - 1;
                }
                else
                {
                    Response.Redirect("~/ShoppingCart");
                }
            }
            else
            {
                if (op == "plus")
                {
                    result = qtyAux + 1;
                }
                else
                {
                    Response.Redirect("~/");
                }
            }
            
            int index = shoppingCartList.IndexOf(itemListSelected);

            itemListSelected.cantidad = result;

            shoppingCartList[index] = itemListSelected;

            Session[Session.SessionID + "shoppingCartList"] = shoppingCartList;

            Response.Redirect("~/ShoppingCart");

        }
    }
}