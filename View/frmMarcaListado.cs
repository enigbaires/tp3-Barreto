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
    public partial class frmMarcaListado : Form
    {
        public frmMarcaListado()
        {
            InitializeComponent();
        }

        DAOMicrosoftSqlServer dao = new DAOMicrosoftSqlServer();

        private void frmMarcaListado_Load(object sender, EventArgs e)
        {
            dgvConsultaListadoMarca.DataSource = dao.ListarMarcaCompleta();
            dgvConsultaListadoMarca.Columns[0].Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmSalir frm = new frmSalir();
            frm.ShowDialog();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            frmMarcaAlta frm = new frmMarcaAlta();
            frm.ShowDialog();
            dgvConsultaListadoMarca.DataSource = dao.ListarMarcaCompleta();
            dgvConsultaListadoMarca.Columns[0].Visible = false;
        }

        Marca marca = new Marca();

        private void btnBaja_Click(object sender, EventArgs e)
        {
            marca = (Marca)dgvConsultaListadoMarca.CurrentRow.DataBoundItem;
            frmMarcaBaja frm = new frmMarcaBaja();
            frm.lblMarca.Text = marca.descripcion;
            frm.ShowDialog();
            dgvConsultaListadoMarca.DataSource = dao.ListarMarcaCompleta();
            dgvConsultaListadoMarca.Columns[0].Visible = false;
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            marca = (Marca)dgvConsultaListadoMarca.CurrentRow.DataBoundItem;
            frmMarcaModificacion frm = new frmMarcaModificacion();
            frm.lblIdMarca.Text = Convert.ToString(marca.id);
            frm.ShowDialog();
            dgvConsultaListadoMarca.DataSource = dao.ListarMarcaCompleta();
            dgvConsultaListadoMarca.Columns[0].Visible = false;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
