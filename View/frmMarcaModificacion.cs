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
    public partial class frmMarcaModificacion : Form
    {
        public frmMarcaModificacion()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DAOMicrosoftSqlServer dao = new DAOMicrosoftSqlServer();

            if (dao.ModificacionMarca(Convert.ToInt32(lblIdMarca.Text), tbDescripcion.Text))
            {
                MessageBox.Show("Marca modificada");
                Dispose();
            }
            else
            {
                MessageBox.Show("Marca no pudo ser modificada");
                Dispose();
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
