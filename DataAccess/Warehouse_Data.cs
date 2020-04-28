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
    public class Warehouse_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public bool InsertWarehouse(Warehouse_Entity warehouse)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("add_warehouse", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter p_name = new SqlParameter();
                p_name.ParameterName = "@name";
                p_name.SqlDbType = SqlDbType.VarChar;
                p_name.Size = 25;
                p_name.Value = warehouse.name;

                SqlParameter p_desc = new SqlParameter();
                p_desc.ParameterName = "@desc";
                p_desc.SqlDbType = SqlDbType.VarChar;
                p_desc.Size = 50;
                p_desc.Value = warehouse.description;

                SqlParameter p_address = new SqlParameter();
                p_address.ParameterName = "@address";
                p_address.SqlDbType = SqlDbType.VarChar;
                p_address.Size = 20;
                p_address.Value = warehouse.address;

                SqlParameter fkClientBusiness = new SqlParameter();
                fkClientBusiness.ParameterName = "@fkClientBusiness";
                fkClientBusiness.SqlDbType = SqlDbType.Int;
                fkClientBusiness.Value = warehouse.clientBusiness.id_client_business;

                sqlCommand.Parameters.Add(p_name);
                sqlCommand.Parameters.Add(p_desc);
                sqlCommand.Parameters.Add(p_address);
                sqlCommand.Parameters.Add(fkClientBusiness);

                sqlCommand.ExecuteNonQuery();

                response = true;
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return response;
        }
    }
}
