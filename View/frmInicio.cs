using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void listadoDeArtículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaListado frm = new frmConsultaListado();
            DAOMicrosoftSqlServer dao = new DAOMicrosoftSqlServer();
            frm.dgvConsultaListado.DataSource = dao.Listar();
            frm.dgvConsultaListado.Columns[0].Visible = false;
            frm.dgvConsultaListado.Columns[1].Visible = false;
            frm.dgvConsultaListado.Columns[6].Visible = false;
            frm.ShowDialog();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            
        }

        private void detalleDeArtículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaDetalle frm = new frmConsultaDetalle();
            frm.btnBuscar.Enabled = true;
            frm.tbCodigo.ReadOnly = false;
            frm.lblIndicacion.Text = "Coloque el código en la casilla Código y haga clic en Detalle para ver el artículo";
            frm.ShowDialog();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            frmBusqueda frm = new frmBusqueda();
            frm.ShowDialog();
        }

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAlta frm = new frmAlta();
            frm.ShowDialog();
        }

        private void modificaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmModificacion frm = new frmModificacion();
            frm.ShowDialog();
        }

        private void bajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBaja frm = new frmBaja();
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmSalir frm = new frmSalir();
            frm.ShowDialog();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcaListado frm = new frmMarcaListado();
            frm.ShowDialog();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoriaListado frm = new frmCategoriaListado();
            frm.ShowDialog();
        }
    }
}
