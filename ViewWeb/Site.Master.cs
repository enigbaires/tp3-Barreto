using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewWeb
{
    public partial class SiteMaster : MasterPage
    {
        DAOMicrosoftSqlServer dao = new DAOMicrosoftSqlServer();

        DAOItemList dAOItemList = new DAOItemList();

        List<ArticuloListado> itemLists = new List<ArticuloListado>();

        List<ArticuloListado> itemListsFiltered = new List<ArticuloListado>();
        public List<CarritoDeCompras> shoppingCartList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "TP 3 ";

            if (!IsPostBack)
            {
                itemLists = dAOItemList.List();
                itemListsFiltered = itemLists;
                Session[Session.SessionID + "itemLists"] = itemLists;
                Session[Session.SessionID + "itemListsFiltered"] = itemListsFiltered;
            }

            shoppingCartList = (List<CarritoDeCompras>)Session[Session.SessionID + "shoppingCartList"];

            int qty;

            if(shoppingCartList == null)
            {
                qty = 0;
            }
            else
            {
                qty = shoppingCartList.Count();
            }
            lblCart.Text = "Cart (" + qty + ")";
        }
    }
}