using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;
using System.Windows.Forms;

namespace Controller
{
    public class DAOMicrosoftSqlServer
    {
        String connectionString = "data source = YY118297\\SQLEXPRESS; initial catalog = CATALOGO_DB;integrated security = sspi;";
        
        public String LeerUnaDescripcionDB(String tipo, String commandText)
        {
            String result = "No Encontrado";
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = commandText;
                command.Connection = connection;
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    result = dataReader.GetString(0);
                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló "+ tipo + ": " + ex.ToString());
            }
            return result;
        }
        
        
        public String BuscarMarca(int nroMarca)
        {
            String result = "No se encontro marca";
            String commandText = "select Descripcion from MARCAS where Id = " + nroMarca;
            String descripcion = LeerUnaDescripcionDB("BuscarMarca", commandText);
            result = descripcion;
            return result;            
        }

        public String BuscarCategoria(int nroCategoria)
        {
            String result = "No se encontro marca";
            String commandText = "select Descripcion from CATEGORIAS where Id = " + nroCategoria;
            String descripcion = LeerUnaDescripcionDB("BuscarCategoria", commandText);
            result = descripcion;
            return result;
        }

        public List<ArticuloListado> Listar()
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            List<ArticuloListado> articulo = new List<ArticuloListado>();
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from ARTICULOS";
                command.Connection = connection;
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    ArticuloListado aux = new ArticuloListado();
                    aux.id = dataReader.GetInt32(0);
                    aux.codigo = dataReader.GetString(1);
                    aux.nombre = dataReader.GetString(2);
                    aux.descripcion = dataReader.GetString(3);
                    aux.marca = BuscarMarca(dataReader.GetInt32(4));
                    aux.categoria = BuscarCategoria(dataReader.GetInt32(5));
                    aux.imagen = dataReader.GetString(6);
                    aux.precio = Convert.ToString("$ "+Math.Round((decimal)dataReader.GetSqlMoney(7),2));
                    articulo.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló Listar: " + ex.ToString());
            }
            connection.Close();
            return articulo;
        }

        public int BuscarIdMarcaPrimero(string marca)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            int result = 0;
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Id from MARCAS where Descripcion like '%" + marca + "%'";
                command.Connection = connection;
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    result = dataReader.GetInt32(0);
                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló BuscarIdMarcaPrimero: " + ex.ToString());
            }
            connection.Close();
            return result;
        }

        public int BuscarIdCategoriaPrimero(string categoria)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            int result = 0;
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Id from CATEGORIAS where Descripcion like '%" + categoria + "%'";
                command.Connection = connection;
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    result = dataReader.GetInt32(0);
                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló BuscarIdCategoriaPrimero: " + ex.ToString());
            }
            connection.Close();
            return result;
        }

        public int BuscarCodigoArticulo(String codigoArticulo)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            int result = 0;
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from ARTICULOS where Codigo = '" + codigoArticulo + "'";
                command.Connection = connection;
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    result++;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló BuscarCodigoArticulo: " + ex.ToString());
            }            
            connection.Close();
            return result;
        }

        public ArticuloListado BuscarArticulo(String codigoArticulo)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            ArticuloListado aux = new ArticuloListado();
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from ARTICULOS where Codigo = '" + codigoArticulo + "'";
                command.Connection = connection;
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    aux.id = dataReader.GetInt32(0);
                    aux.codigo = dataReader.GetString(1);
                    aux.nombre = dataReader.GetString(2);
                    aux.descripcion = dataReader.GetString(3);
                    aux.marca = BuscarMarca(dataReader.GetInt32(4));
                    aux.categoria = BuscarCategoria(dataReader.GetInt32(5));
                    aux.imagen = dataReader.GetString(6);
                    aux.precio = Convert.ToString("$ " + Math.Round((decimal)dataReader.GetSqlMoney(7), 2));
                    connection.Close();
                    return aux;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló BuscarArticulo: " + ex.ToString());
            }
            connection.Close();
            return aux;
        }

        public bool ModificacionArticulo(Articulo articulo)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            bool result = false;
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "Update ARTICULOS Set Codigo='" + articulo.codigo + "', Nombre='" + articulo.nombre + "', Descripcion='" + articulo.descripcion + "', IdMarca='" + articulo.marca + "', IdCategoria='" + articulo.categoria + "', ImagenURL='" + articulo.imagen + "', Precio=" + articulo.precio + " Where Id=" + articulo.id;
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló ModificacionArticulo: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public bool AltaArticulo(Articulo articulo)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            bool result = false;
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@codigo", articulo.codigo);
                command.Parameters.AddWithValue("@nombre", articulo.nombre);
                command.Parameters.AddWithValue("@descripcion", articulo.descripcion);
                command.Parameters.AddWithValue("@marca", articulo.marca);
                command.Parameters.AddWithValue("@categoria", articulo.categoria);
                command.Parameters.AddWithValue("@imagen", articulo.imagen);
                command.Parameters.AddWithValue("@precio", articulo.precio);
                command.CommandText = "insert into ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenURL, Precio) values (@codigo,@nombre,@descripcion,@marca,@categoria,@imagen,@precio)";
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló AltaArticulo: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public int BuscarIdCategoria(String categoria)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            int result = 0;
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Id from CATEGORIAS where Descripcion = '" + categoria + "'";
                command.Connection = connection;
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    result = dataReader.GetInt32(0);
                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló BuscarIdCategoria: " + ex.ToString());
            }
            connection.Close();
            return result;
        }

        public int BuscarIdMarca(String marca)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            int result = 0;
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Id from MARCAS where Descripcion = '" + marca + "'";
                command.Connection = connection;
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    result = dataReader.GetInt32(0);
                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló BuscarIdCategoria: " + ex.ToString());
            }
            connection.Close();
            return result;
        }

        public List<Marca> ListarMarca()
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            List<Marca> marca = new List<Marca>();
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from MARCAS";
                command.Connection = connection;
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Marca aux = new Marca();
                    aux.id = dataReader.GetInt32(0);
                    aux.descripcion = dataReader.GetString(1);
                    marca.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló ListarMarca: " + ex.ToString());
            }
            connection.Close();
            return marca;
        }

        public List<Categoria> ListarCategoria()
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            List<Categoria> categoria = new List<Categoria>();
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from CATEGORIAS";
                command.Connection = connection;
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Categoria aux = new Categoria();
                    aux.id = dataReader.GetInt32(0);
                    aux.descripcion = dataReader.GetString(1);
                    categoria.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló ListarCategoria: " + ex.ToString());
            }
            connection.Close();
            return categoria;
        }

        public bool BajaArticulo(int id)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            bool result = false;
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from ARTICULOS where Id = " + id;
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló BajaArticulo: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public int BuscarIdArticulo(String codigo)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            int result = 0;
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Id from ARTICULOS where Codigo = '" + codigo + "'";
                command.Connection = connection;
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    result = dataReader.GetInt32(0);
                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló BuscarIdArticulo: " + ex.ToString());
            }
            connection.Close();
            return result;
        }

        public List<ArticuloListado> BuscarArticuloListado(String sentencia)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            List<ArticuloListado> articulos = new List<ArticuloListado>();
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = sentencia;
                command.Connection = connection;
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    ArticuloListado aux = new ArticuloListado();
                    aux.id = dataReader.GetInt32(0);
                    aux.codigo = dataReader.GetString(1);
                    aux.nombre = dataReader.GetString(2);
                    aux.descripcion = dataReader.GetString(3);
                    aux.marca = BuscarMarca(dataReader.GetInt32(4));
                    aux.categoria = BuscarCategoria(dataReader.GetInt32(5));
                    aux.imagen = dataReader.GetString(6);
                    aux.precio = Convert.ToString("$ " + Math.Round((decimal)dataReader.GetSqlMoney(7), 2));
                    articulos.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló BuscarArticuloListado: " + ex.ToString());
            }
            connection.Close();
            return articulos;
        }

        public List<Categoria> ListarCategoriaCompleta()
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            List<Categoria> categoria = new List<Categoria>();
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from CATEGORIAS";
                command.Connection = connection;
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Categoria aux = new Categoria();
                    aux.id = dataReader.GetInt32(0);
                    aux.descripcion = dataReader.GetString(1);
                    categoria.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló ListarCategoriaCompleta: " + ex.ToString());
            }
            connection.Close();
            return categoria;
        }

        public List<Marca> ListarMarcaCompleta()
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            List<Marca> marcas = new List<Marca>();
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from MARCAS";
                command.Connection = connection;
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Marca aux = new Marca();
                    aux.id = dataReader.GetInt32(0);
                    aux.descripcion = dataReader.GetString(1);
                    marcas.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló ListarMarcaCompleta: " + ex.ToString());
            }
            connection.Close();
            return marcas;
        }

        public bool AltaCategoria(String descripcion)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            bool result = false;
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.CommandText = "insert into CATEGORIAS(Descripcion) values (@descripcion)";
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló AltaCategoria: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public bool AltaMarca(String descripcion)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            bool result = false;
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.CommandText = "insert into MARCAS(Descripcion) values (@descripcion)";
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló AltaMarca: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public bool BajaCategoria(int id)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            bool result = false;
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from CATEGORIAS where Id = " + id;
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló BajaCategoria: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public bool BajaMarca(int id)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            bool result = false;
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from MARCAS where Id = " + id;
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló BajaMarca: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public bool ModificacionCategoria(int id, String descripcion)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            bool result = false;
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "Update CATEGORIAS Set Descripcion='"+ descripcion + "' Where Id="+id;
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló ModificacionCategoria: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public bool ModificacionMarca(int id, String descripcion)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            bool result = false;
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.CommandText = "Update MARCAS Set Descripcion=@descripcion Where Id=@id";
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló ModificacionMarca: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}
