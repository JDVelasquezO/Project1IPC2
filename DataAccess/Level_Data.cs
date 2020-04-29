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
    public class Level_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public bool InsertLevel(Level_Entity level)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("add_level", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter p_height = new SqlParameter();
                p_height.ParameterName = "@height";
                p_height.SqlDbType = SqlDbType.Int;
                p_height.Value = 2;

                SqlParameter fkIdShelf = new SqlParameter();
                fkIdShelf.ParameterName = "@fkIdShelf";
                fkIdShelf.SqlDbType = SqlDbType.Int;
                fkIdShelf.Value = level.shelf.id_sheld;
                
                sqlCommand.Parameters.Add(p_height);
                sqlCommand.Parameters.Add(fkIdShelf);

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
