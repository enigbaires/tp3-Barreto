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
    public partial class frmModificacion : Form
    {
        public frmModificacion()
        {
            InitializeComponent();
        }

        ArticuloListado articuloListado = new ArticuloListado();


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DAOMicrosoftSqlServer dao = new DAOMicrosoftSqlServer();

            if (dao.BuscarCodigoArticulo(tbCodigo.Text) == 0)
            {
                MessageBox.Show("Código inexistente");
                tbCodigo.Text = "";
                tbNombre.Text = "";
                tbDescripcion.Text = "";
                tbPrecio.Text = "";
                tbUrl.Text = "";
                pbImagenArticulo.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/8/89/Symbol_delete_vote.svg/40px-Symbol_delete_vote.svg.png");
            }
            else
            {   
                articuloListado = dao.BuscarArticulo(tbCodigo.Text);
                tbCodigo.Text = articuloListado.codigo;
                tbNombre.Text = articuloListado.nombre;
                tbDescripcion.Text = articuloListado.descripcion;
                cbMarca.Text = articuloListado.marca;
                cbCategoria.Text = articuloListado.categoria;
                tbPrecio.Text = articuloListado.precio.Remove(0,2);
                tbUrl.Text = articuloListado.imagen;
                try
                {
                    pbImagenArticulo.Load(articuloListado.imagen);
                }
                catch (Exception)
                {
                    pbImagenArticulo.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/8/89/Symbol_delete_vote.svg/40px-Symbol_delete_vote.svg.png");
                }
                tbNombre.ReadOnly = false;
                tbDescripcion.ReadOnly = false;
                tbPrecio.ReadOnly = false;
                tbUrl.ReadOnly = false;
                btnModificacion.Enabled = true;
                cbCategoria.BackColor = Color.White;
                cbMarca.BackColor = Color.White;
            }
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            bool camposSinCompletar = false;

            if (tbCodigo.TextLength == 0)
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

            if (tbUrl.TextLength == 0)
            {
                tbUrl.BackColor = Color.Red;
                camposSinCompletar = true;
            }

            if (camposSinCompletar)
            {
                MessageBox.Show("Hay campos sin completar");
            }
            else
            {
                DAOMicrosoftSqlServer dao = new DAOMicrosoftSqlServer();
                Articulo articulo = new Articulo();
                Marca descripcionMarca = new Marca();
                descripcionMarca = (Marca)cbMarca.SelectedItem;
                Categoria descripcionCategoria = new Categoria();
                descripcionCategoria = (Categoria)cbCategoria.SelectedItem;
                articulo.id = articuloListado.id;
                articulo.codigo = tbCodigo.Text;
                articulo.nombre = tbNombre.Text;
                articulo.descripcion = tbDescripcion.Text;
                articulo.marca = (int)descripcionMarca.id;
                articulo.categoria = (int)descripcionCategoria.id;
                articulo.precio = Convert.ToDecimal(tbPrecio.Text);
                articulo.imagen = tbUrl.Text;

                if (dao.BuscarCodigoArticulo(tbCodigo.Text) != 0)
                {
                    if (dao.ModificacionArticulo(articulo))
                    {
                        MessageBox.Show("Artículo modificado");
                        tbCodigo.Text = "";
                        tbNombre.Text = "";
                        tbDescripcion.Text = "";
                        tbPrecio.Text = "";
                        tbUrl.Text = "";
                        pbImagenArticulo.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/8/89/Symbol_delete_vote.svg/40px-Symbol_delete_vote.svg.png");
                    }
                    else
                    {
                        MessageBox.Show("Artículo no pudo ser modificado");
                    }
                }
                else
                {
                    if (dao.AltaArticulo(articulo))
                    {
                        MessageBox.Show("Artículo dado de alta");
                        tbCodigo.Text = "";
                        tbNombre.Text = "";
                        tbDescripcion.Text = "";
                        tbPrecio.Text = "";
                        tbUrl.Text = "";
                        pbImagenArticulo.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/8/89/Symbol_delete_vote.svg/40px-Symbol_delete_vote.svg.png");
                    }
                    else
                    {
                        MessageBox.Show("Artículo no pudo ser dado de alta");
                    }
                }
            }
        }

        private void frmModificacion_Load(object sender, EventArgs e)
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
        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            tbNombre.BackColor = Color.White;
        }

        private void tbDescripcion_TextChanged(object sender, EventArgs e)
        {
            tbDescripcion.BackColor = Color.White;
        }

        private void tbPrecio_TextChanged(object sender, EventArgs e)
        {
            tbPrecio.BackColor = Color.White;
        }

        private void tbUrl_TextChanged(object sender, EventArgs e)
        {
            tbUrl.BackColor = Color.White;
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
