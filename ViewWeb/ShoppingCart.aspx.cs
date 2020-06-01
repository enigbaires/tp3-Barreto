using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace ViewWeb
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        public List<CarritoDeCompras> shoppingCartList { get; set; }
        public ArticuloListado itemListSelected { get; set; }
        public CarritoDeCompras itemListShoppingCart { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session[Session.SessionID + "itemLists"] == null) Response.Redirect("~/");

            List<ArticuloListado> itemLists = new List<ArticuloListado>();
            itemLists = (List<ArticuloListado>)Session[Session.SessionID + "itemLists"];
            shoppingCartList = (List<CarritoDeCompras>)Session[Session.SessionID + "shoppingCartList"];

            if (Request.QueryString["id"] != null)
            {
                int idItemSelected = Convert.ToInt32(Request.QueryString["id"]);
                itemListSelected = itemLists.Find(J => J.id == idItemSelected);
                DAOCarritoDeCompras dAOCarritoDeCompras = new DAOCarritoDeCompras();
                if (shoppingCartList == null)
                {
                    shoppingCartList = new List<CarritoDeCompras>();
                    shoppingCartList.Add(dAOCarritoDeCompras.AddItem(itemListSelected));
                    Session[Session.SessionID + "shoppingCartList"] = shoppingCartList;
                }
                else
                {
                    itemListShoppingCart = shoppingCartList.Find(J => J.id == idItemSelected);
                    if (itemListShoppingCart == null)
                    {
                        shoppingCartList.Add(dAOCarritoDeCompras.AddItem(itemListSelected));
                        Session[Session.SessionID + "shoppingCartList"] = shoppingCartList;
                    }    
                }   
            }

            if (shoppingCartList != null)
            {
                decimal total = 0;
                foreach (var item in shoppingCartList)
                {
                    decimal aux = item.cantidad * item.precioUnitario;
                    total = total + aux;
                }
                lblTotal.Text = total.ToString();
            }
            else
            {
                Response.Redirect("~/");
            }
        }
    }
}