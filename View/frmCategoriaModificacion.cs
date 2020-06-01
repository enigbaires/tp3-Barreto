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

namespace View
{
    public partial class frmCategoriaModificacion : Form
    {
        public frmCategoriaModificacion()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DAOMicrosoftSqlServer dao = new DAOMicrosoftSqlServer();

            if (dao.ModificacionCategoria(Convert.ToInt32(lblIdCategoria.Text), tbDescripcion.Text))
            {
                MessageBox.Show("Artículo modificado");
                Dispose();
            }
            else
            {
                MessageBox.Show("Artículo no pudo ser modificado");
                Dispose();
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
