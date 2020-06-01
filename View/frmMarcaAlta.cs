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
    public partial class frmMarcaAlta : Form
    {
        public frmMarcaAlta()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (tbDescripcion.Text.Length == 0)
            {
                MessageBox.Show("Se necesita una descripción para poder dar de alta una marca");
            }
            else
            {
                DAOMicrosoftSqlServer dao = new DAOMicrosoftSqlServer();

                if (dao.BuscarIdMarcaPrimero(tbDescripcion.Text) != 0)
                {
                    MessageBox.Show("Ya existe esa Descripción");
                }
                else
                {
                    if (dao.AltaMarca(tbDescripcion.Text))
                    {
                        MessageBox.Show("Marca dada de alta");
                        Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Marca no pudo ser dada de alta");
                    }
                }
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
