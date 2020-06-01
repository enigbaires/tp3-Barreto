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
    public partial class frmMarcaBaja : Form
    {
        public frmMarcaBaja()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DAOMicrosoftSqlServer dao = new DAOMicrosoftSqlServer();
            int idMarca = dao.BuscarIdMarca(lblMarca.Text);
            if (dao.BajaMarca(idMarca))
            {
                MessageBox.Show("Marca dada de baja");
            }
            else
            {
                MessageBox.Show("Marca no pudo ser dada de baja");
            }
            Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
