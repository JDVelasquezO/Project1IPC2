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
    public class Hall_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public bool InsertHall(Hall_Entity hall)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("add_hall", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter p_name = new SqlParameter();
                p_name.ParameterName = "@no_hall";
                p_name.SqlDbType = SqlDbType.Int;
                p_name.Value = hall.no_hall;

                SqlParameter p_width = new SqlParameter();
                p_width.ParameterName = "@width";
                p_width.SqlDbType = SqlDbType.Int;
                p_width.Value = hall.width;

                SqlParameter p_length = new SqlParameter();
                p_length.ParameterName = "@length";
                p_length.SqlDbType = SqlDbType.Int;
                p_length.Value = hall.length;

                SqlParameter fkIdWarehouse = new SqlParameter();
                fkIdWarehouse.ParameterName = "@fkIdWarehouse";
                fkIdWarehouse.SqlDbType = SqlDbType.Int;
                fkIdWarehouse.Value = hall.warehouse.idWarehouse;

                sqlCommand.Parameters.Add(p_name);
                sqlCommand.Parameters.Add(p_width);
                sqlCommand.Parameters.Add(p_length);
                sqlCommand.Parameters.Add(fkIdWarehouse);

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
