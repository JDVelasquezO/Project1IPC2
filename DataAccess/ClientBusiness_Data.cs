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

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("list_client_business", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    ClientBusiness_Entity client_business = new ClientBusiness_Entity();
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

        public ClientBusiness_Entity searchTeacher(int id)
        {
            ClientBusiness_Entity client_business = new ClientBusiness_Entity();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("search_client_business", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idClient";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = id;

                sqlCommand.Parameters.Add(id_parameter);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();

                if (sqlDataReader.HasRows)
                {
                    client_business.id_client_business = Convert.ToInt32(sqlDataReader["Identificador"]);
                    client_business.name_client_business = sqlDataReader["Nombre Empresa"].ToString();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return client_business;
        }
    }
}
