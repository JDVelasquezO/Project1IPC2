using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ClientBusiness_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public List<ClientBusiness_Entity> listClientBusiness()
        {
            List<ClientBusiness_Entity> list = new List<ClientBusiness_Entity>();
            ClientBusiness_Entity client_business = new ClientBusiness_Entity();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("list_client_business", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    client_business.id_client_business = Convert.ToInt32(sqlDataReader["Identificador"]);
                    client_business.name_client_business = sqlDataReader["Nombre Empresa"].ToString();

                    list.Add(client_business);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }
    }
}
