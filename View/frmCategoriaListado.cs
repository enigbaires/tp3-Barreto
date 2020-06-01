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
    public partial class frmCategoriaListado : Form
    {
        public frmCategoriaListado()
        {
            InitializeComponent();
        }

        DAOMicrosoftSqlServer dao = new DAOMicrosoftSqlServer();

        private void frmCategoriaListado_Load(object sender, EventArgs e)
        {
            
            dgvConsultaListadoCategoria.DataSource = dao.ListarCategoriaCompleta();
            dgvConsultaListadoCategoria.Columns[0].Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmSalir frm = new frmSalir();
            frm.ShowDialog();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            frmCategoriaAlta frm = new frmCategoriaAlta();
            frm.ShowDialog();
            dgvConsultaListadoCategoria.DataSource = dao.ListarCategoriaCompleta();
            dgvConsultaListadoCategoria.Columns[0].Visible = false;
        }

        Categoria categoria = new Categoria();
        private void btnBaja_Click(object sender, EventArgs e)
        {   
            categoria = (Categoria)dgvConsultaListadoCategoria.CurrentRow.DataBoundItem;
            frmCategoriaBaja frm = new frmCategoriaBaja();
            frm.lblCategoria.Text = categoria.descripcion;            
            frm.ShowDialog();
            dgvConsultaListadoCategoria.DataSource = dao.ListarCategoriaCompleta();
            dgvConsultaListadoCategoria.Columns[0].Visible = false;
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            categoria = (Categoria)dgvConsultaListadoCategoria.CurrentRow.DataBoundItem;
            frmCategoriaModificacion frm = new frmCategoriaModificacion();
            frm.lblIdCategoria.Text = Convert.ToString(categoria.id);
            frm.ShowDialog();
            dgvConsultaListadoCategoria.DataSource = dao.ListarCategoriaCompleta();
            dgvConsultaListadoCategoria.Columns[0].Visible = false;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
