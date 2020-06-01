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
    public partial class frmConsultaDetalle : Form
    {
        public frmConsultaDetalle()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DAOMicrosoftSqlServer dao = new DAOMicrosoftSqlServer();

            if(dao.BuscarCodigoArticulo(tbCodigo.Text)==0)
            {
                MessageBox.Show("Código inexistente");
                tbCodigo.Text = "";
                tbNombre.Text = "";
                tbDescripcion.Text = "";
                tbMarca.Text = "";
                tbCategoria.Text = "";
                tbPrecio.Text = "";
                pbImagenArticulo.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/8/89/Symbol_delete_vote.svg/40px-Symbol_delete_vote.svg.png");
            }
            else
            {
                ArticuloListado articuloListado = new ArticuloListado();
                articuloListado = dao.BuscarArticulo(tbCodigo.Text);
                tbCodigo.Text = articuloListado.codigo;
                tbNombre.Text = articuloListado.nombre;
                tbDescripcion.Text = articuloListado.descripcion;
                tbMarca.Text = articuloListado.marca;
                tbCategoria.Text = articuloListado.categoria;
                tbPrecio.Text = articuloListado.precio;
                try
                {
                    pbImagenArticulo.Load(articuloListado.imagen);
                }
                catch (Exception)
                {
                    pbImagenArticulo.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/8/89/Symbol_delete_vote.svg/40px-Symbol_delete_vote.svg.png");
                }
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
