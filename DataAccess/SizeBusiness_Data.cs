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
    public class SizeBusiness_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public List<SizeBusiness_Entity> listSizeBusiness()
        {
            List<SizeBusiness_Entity> list = new List<SizeBusiness_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("list_size_business", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    SizeBusiness_Entity size_business = new SizeBusiness_Entity();
                    size_business.id_size_business = Convert.ToInt32(sqlDataReader["Identificador"]);
                    size_business.size = sqlDataReader["Tamaño"].ToString();

                    list.Add(size_business);
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
