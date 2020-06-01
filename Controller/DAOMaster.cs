using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;

namespace Controller
{
    public class DAOMaster
    {
        private String connectionString = "data source = YY118297\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi;";

        public String SearchString(String type, String commandText)
        {
            String result = "Not Found";
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
            catch (Exception)
            {

                throw;
            }
            connection.Close();
            return result;
        }

    }
}
