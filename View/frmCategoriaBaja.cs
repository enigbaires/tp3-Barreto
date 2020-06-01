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
    public partial class frmCategoriaBaja : Form
    {
        public frmCategoriaBaja()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DAOMicrosoftSqlServer dao = new DAOMicrosoftSqlServer();
            int idCategoria = dao.BuscarIdCategoria(lblCategoria.Text);
            if (dao.BajaCategoria(idCategoria))
            {
                MessageBox.Show("Artículo dado de baja");
            }
            else
            {
                MessageBox.Show("Artículo no pudo ser dado de baja");
            }
            Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
