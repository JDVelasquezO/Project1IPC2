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
    public class TypeBusiness_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public List<TypeBusiness_Entity> listTypeCard()
        {
            List<TypeBusiness_Entity> list = new List<TypeBusiness_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("list_type_business", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    TypeBusiness_Entity type_business = new TypeBusiness_Entity();
                    type_business.id_type_business = Convert.ToInt32(sqlDataReader["Identificador"]);
                    type_business.type_business = sqlDataReader["Tipo Empresa"].ToString();

                    list.Add(type_business);
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
