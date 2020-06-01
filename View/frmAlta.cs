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
    public partial class frmAlta : Form
    {
        public frmAlta()
        {
            InitializeComponent();
        }

        private void frmAlta_Load(object sender, EventArgs e)
        {
            DAOMicrosoftSqlServer dao = new DAOMicrosoftSqlServer();

            try
            {
                cbCategoria.DataSource = dao.ListarCategoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló la carga de la Categoria: " + ex.ToString());
            }

            try
            {
                cbMarca.DataSource = dao.ListarMarca();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló la carga de la Marca: " + ex.ToString());
            }
        }

        private void tbCodigo_TextChanged(object sender, EventArgs e)
        {
            tbCodigo.BackColor = Color.White;
        }

        private void tbDescripcion_TextChanged(object sender, EventArgs e)
        {
            tbDescripcion.BackColor = Color.White;
        }
                
        private void tbPrecio_TextChanged(object sender, EventArgs e)
        {
            tbPrecio.BackColor = Color.White;
        }

        private void tbUrlImagen_TextChanged(object sender, EventArgs e)
        {
            tbUrlImagen.BackColor = Color.White;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            bool camposSinCompletar = false;

            if(tbCodigo.TextLength==0)
            {                
                tbCodigo.BackColor = Color.Red;
                camposSinCompletar = true;
            }

            if (tbNombre.TextLength == 0)
            {
                tbNombre.BackColor = Color.Red;
                camposSinCompletar = true;
            }

            if (tbDescripcion.TextLength == 0)
            {
                tbDescripcion.BackColor = Color.Red;
                camposSinCompletar = true;
            }

            if (tbPrecio.TextLength == 0)
            {
                tbPrecio.BackColor = Color.Red;
                camposSinCompletar = true;
            }

            if (tbUrlImagen.TextLength == 0)
            {
                tbUrlImagen.BackColor = Color.Red;
                camposSinCompletar = true;
            }

            if(camposSinCompletar)
            {
                MessageBox.Show("Hay campos sin completar");
            }
            else
            {
                DAOMicrosoftSqlServer dao = new DAOMicrosoftSqlServer();
                
                if(dao.BuscarCodigoArticulo(tbCodigo.Text)!=0)
                {
                    MessageBox.Show("Ya existe ese Artículo");
                }
                else
                {
                    Articulo articulo = new Articulo();
                    Marca descripcionMarca = new Marca();
                    descripcionMarca = (Marca)cbMarca.SelectedItem;
                    Categoria descripcionCategoria = new Categoria();
                    descripcionCategoria = (Categoria)cbCategoria.SelectedItem;
                    articulo.codigo = tbCodigo.Text;
                    articulo.nombre = tbNombre.Text;
                    articulo.descripcion = tbDescripcion.Text;
                    articulo.marca = (int)descripcionMarca.id;
                    articulo.categoria = (int)descripcionCategoria.id;
                    articulo.precio = Convert.ToDecimal(tbPrecio.Text);
                    articulo.imagen = tbUrlImagen.Text;
                    if(dao.AltaArticulo(articulo))
                    {
                        MessageBox.Show("Artículo dado de alta");
                        Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Artículo no pudo ser dado de alta");
                    }
                }
            }
        }

        private void tbCodigo_MouseClick(object sender, MouseEventArgs e)
        {
            tbCodigo.BackColor = Color.White;
        }

        private void tbNombre_MouseClick(object sender, MouseEventArgs e)
        {
            tbNombre.BackColor = Color.White;
        }

        private void tbDescripcion_MouseClick(object sender, MouseEventArgs e)
        {
            tbDescripcion.BackColor = Color.White;
        }
                
        private void tbPrecio_MouseClick(object sender, MouseEventArgs e)
        {
            tbPrecio.BackColor = Color.White;
        }

        private void tbUrlImagen_MouseClick(object sender, MouseEventArgs e)
        {
            tbUrlImagen.BackColor = Color.White;
        }

        private void tbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                if (e.KeyChar != 46)
                {
                    e.Handled = true;
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
