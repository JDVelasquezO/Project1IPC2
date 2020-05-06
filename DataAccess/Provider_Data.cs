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
    public class Provider_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public List<Provider_Entity> getLevelsByClientBusiness()
        {
            List<Provider_Entity> list = new List<Provider_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("SELECT * FROM provider_", sqlConnection);
                
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Provider_Entity provider = new Provider_Entity();
                    provider.id_provider = Convert.ToInt32(sqlDataReader["id_provider"]);
                    provider.nit_provider = sqlDataReader["nit"].ToString();
                    provider.name_provider = sqlDataReader["name_provider"].ToString();
                    provider.phone_provider = sqlDataReader["phone"].ToString();
                    provider.limit_credit = sqlDataReader["limit_credit"].ToString();

                    list.Add(provider);
                }

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }
    }
}
