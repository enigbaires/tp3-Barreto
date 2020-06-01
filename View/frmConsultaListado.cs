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
    public partial class frmConsultaListado : Form
    {
        public frmConsultaListado()
        {
            InitializeComponent();
        }
        private void btnConsultaDetalle_Click(object sender, EventArgs e)
        {
            ArticuloListado articuloListado = new ArticuloListado();
            articuloListado = (ArticuloListado)dgvConsultaListado.CurrentRow.DataBoundItem;
            frmConsultaDetalle frm = new frmConsultaDetalle();
            frm.tbCodigo.Text = articuloListado.codigo;
            frm.tbNombre.Text = articuloListado.nombre;
            frm.tbDescripcion.Text = articuloListado.descripcion;
            frm.tbMarca.Text = articuloListado.marca;
            frm.tbCategoria.Text = articuloListado.categoria;
            frm.tbPrecio.Text = articuloListado.precio;
            try
                {
                    frm.pbImagenArticulo.Load(articuloListado.imagen);
                }
                catch (Exception)
                {
                    frm.pbImagenArticulo.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/8/89/Symbol_delete_vote.svg/40px-Symbol_delete_vote.svg.png");
                }
            frm.ShowDialog();
        }

        private void frmConsultaListado_Load(object sender, EventArgs e)
        {

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
