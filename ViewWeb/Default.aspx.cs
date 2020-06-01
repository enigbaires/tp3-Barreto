using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using Model;

namespace ViewWeb
{
    public partial class _Default : Page
    {
        DAOMicrosoftSqlServer dao = new DAOMicrosoftSqlServer();

        DAOItemList dAOItemList = new DAOItemList();

        List<ArticuloListado> itemLists = new List<ArticuloListado>();

        List<ArticuloListado> itemListsFiltered = new List<ArticuloListado>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                itemLists = dAOItemList.List();
                itemListsFiltered = itemLists;
                Session[Session.SessionID + "itemLists"] = itemLists;
                Session[Session.SessionID + "itemListsFiltered"] = itemListsFiltered;
            }
            itemListsFiltered = (List<ArticuloListado>)Session[Session.SessionID + "itemListsFiltered"];
            repeater.DataSource = itemListsFiltered;
            repeater.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbCodigo.Text.Length == 0 && tbNombre.Text.Length == 0 && tbDescripcion.Text.Length == 0 && tbMarca.Text.Length == 0 && tbCategoria.Text.Length == 0 && tbPrecio.Text.Length == 0)
            {
                Session[Session.SessionID + "itemListsFiltered"] = itemLists;
                Response.Redirect("~/");
            }
            else
            {
                DAOMicrosoftSqlServer dao = new DAOMicrosoftSqlServer();
                String sentenciaInicial = "select * from ARTICULOS where ";
                String sentenciaFinal = "select * from ARTICULOS where ";

                if (tbCodigo.Text.Length != 0)
                {
                    sentenciaFinal = sentenciaFinal + "Codigo like '%" + tbCodigo.Text + "%'";
                }

                if (tbNombre.Text.Length != 0)
                {
                    if (sentenciaInicial == sentenciaFinal)
                    {
                        sentenciaFinal = sentenciaFinal + "Nombre like '%" + tbNombre.Text + "%'";
                    }
                    else
                    {
                        sentenciaFinal = sentenciaFinal + " and Nombre like '%" + tbNombre.Text + "%'";
                    }
                }

                if (tbDescripcion.Text.Length != 0)
                {
                    if (sentenciaInicial == sentenciaFinal)
                    {
                        sentenciaFinal = sentenciaFinal + "Descripcion like '%" + tbDescripcion.Text + "%'";
                    }
                    else
                    {
                        sentenciaFinal = sentenciaFinal + " and Descripcion like '%" + tbDescripcion.Text + "%'";
                    }

                }

                if (tbMarca.Text.Length != 0)
                {
                    int marca = dao.BuscarIdMarcaPrimero(tbMarca.Text);

                    if (sentenciaInicial == sentenciaFinal)
                    {
                        sentenciaFinal = sentenciaFinal + "IdMarca = " + marca;
                    }
                    else
                    {
                        sentenciaFinal = sentenciaFinal + " and IdMarca = " + marca;
                    }
                }

                if (tbCategoria.Text.Length != 0)
                {
                    int categoria = dao.BuscarIdCategoriaPrimero(tbCategoria.Text);

                    if (sentenciaInicial == sentenciaFinal)
                    {
                        sentenciaFinal = sentenciaFinal + "IdCategoria = " + categoria;
                    }
                    else
                    {
                        sentenciaFinal = sentenciaFinal + " and IdCategoria = " + categoria;
                    }
                }

                if (tbPrecio.Text.Length != 0)
                {
                    int categoria = dao.BuscarIdCategoriaPrimero(tbCategoria.Text);

                    if (sentenciaInicial == sentenciaFinal)
                    {
                        sentenciaFinal = sentenciaFinal + "Precio like '%" + tbPrecio.Text + "%'";
                    }
                    else
                    {
                        sentenciaFinal = sentenciaFinal + " and Precio like '%" + tbPrecio.Text + "%'";
                    }
                }

                itemListsFiltered = dao.BuscarArticuloListado(sentenciaFinal);
                Session[Session.SessionID + "itemListsFiltered"] = itemListsFiltered;
                repeater.DataSource = itemListsFiltered;
                repeater.DataBind();
            }
        }
    }
}