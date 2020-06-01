using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Controller
{
    public class DAOItemList : DAOMaster
    {
        private String connectionString = "data source = YY118297\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi;";

        public List<ArticuloListado> List()
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            List<ArticuloListado> articulos = new List<ArticuloListado>();
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from ARTICULOS";
                command.Connection = connection;
                connection.Open();
                dataReader = command.ExecuteReader();
                DAOBrand dAOBrand = new DAOBrand();
                DAOCategory dAOCategory = new DAOCategory();
                while (dataReader.Read())
                {
                    ArticuloListado aux = new ArticuloListado();
                    aux.id = dataReader.GetInt32(0);
                    aux.codigo = dataReader.GetString(1);
                    aux.nombre = dataReader.GetString(2);
                    aux.descripcion = dataReader.GetString(3);
                    aux.marca = dAOBrand.SearchBrand(dataReader.GetInt32(4));
                    aux.categoria = dAOCategory.SearchCategory(dataReader.GetInt32(5));
                    aux.imagen = dataReader.GetString(6);
                    aux.precio = Convert.ToString("$ " + Math.Round((decimal)dataReader.GetSqlMoney(7), 2));
                    articulos.Add(aux);
                }
            }
            catch (Exception)
            {
                throw;
            }
            connection.Close();
            return articulos;
        }

        public ArticuloListado SearchItemList(int id)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            ArticuloListado articuloListado = new ArticuloListado();
            try
            {
                connection.ConnectionString = connectionString;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from ARTICULOS where Id = "+ id;
                command.Connection = connection;
                connection.Open();
                dataReader = command.ExecuteReader();
                DAOBrand dAOBrand = new DAOBrand();
                DAOCategory dAOCategory = new DAOCategory();
                while (dataReader.Read())
                {
                    articuloListado.id = dataReader.GetInt32(0);
                    articuloListado.codigo = dataReader.GetString(1);
                    articuloListado.nombre = dataReader.GetString(2);
                    articuloListado.descripcion = dataReader.GetString(3);
                    articuloListado.marca = dAOBrand.SearchBrand(dataReader.GetInt32(4));
                    articuloListado.categoria = dAOCategory.SearchCategory(dataReader.GetInt32(5));
                    articuloListado.imagen = dataReader.GetString(6);
                    articuloListado.precio = Convert.ToString("$ " + Math.Round((decimal)dataReader.GetSqlMoney(7), 2));
                    connection.Close();
                    return articuloListado;
                }
            }
            catch (Exception)
            {
                throw;
            }
            connection.Close();
            return articuloListado;
        }
    }
}
