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
    public class UserOperative_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public List<UserOperative_Entity> searchOperators(int id)
        {
            List<UserOperative_Entity> list = new List<UserOperative_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("search_user_operative", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idAdminServices";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = id;

                sqlCommand.Parameters.Add(id_parameter);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    UserOperative_Entity operative = new UserOperative_Entity();
                    operative.id_user_operative = Convert.ToInt32(sqlDataReader["Identificador"]);
                    operative.name_operative = sqlDataReader["Nombre"].ToString();
                    operative.job = sqlDataReader["Puesto"].ToString();
                    operative.celphone = sqlDataReader["Celular"].ToString();

                    list.Add(operative);
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
