using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Controller;

namespace View
{
    public partial class frmBusqueda : Form
    {
        public frmBusqueda()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbCodigo.Text.Length == 0 && tbNombre.Text.Length == 0 && tbDescripcion.Text.Length == 0 && tbMarca.Text.Length == 0 && tbCategoria.Text.Length == 0 && tbPrecio.Text.Length == 0)
            {
                MessageBox.Show("No hay información para la búsqueda");
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
                    if (sentenciaInicial==sentenciaFinal)
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
                        sentenciaFinal = sentenciaFinal + "Marca = " + marca;
                    }
                    else
                    {
                        sentenciaFinal = sentenciaFinal + " and Marca = " + marca;
                    }
                }

                if (tbCategoria.Text.Length != 0)
                {
                    int categoria = dao.BuscarIdCategoriaPrimero(tbCategoria.Text);

                    if (sentenciaInicial == sentenciaFinal)
                    {
                        sentenciaFinal = sentenciaFinal + "Categoria = " + categoria;
                    }
                    else
                    {
                        sentenciaFinal = sentenciaFinal + " and Categoria = " + categoria;
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
                frmConsultaListado frm = new frmConsultaListado();
                frm.dgvConsultaListado.DataSource = dao.BuscarArticuloListado(sentenciaFinal);
                frm.dgvConsultaListado.Columns[0].Visible = false;
                frm.dgvConsultaListado.Columns[1].Visible = false;
                frm.dgvConsultaListado.Columns[6].Visible = false;
                frm.ShowDialog();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmSalir frm = new frmSalir();
            frm.ShowDialog();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
