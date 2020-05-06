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

        public List<Level_Entity> getLevelsByClientBusiness(int idClientBusiness)
        {
            List<Level_Entity> list = new List<Level_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("return_level", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idClientBusiness";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = idClientBusiness;

                sqlCommand.Parameters.Add(id_parameter);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Level_Entity level = new Level_Entity();
                    level.id_level = Convert.ToInt32(sqlDataReader["ID Nivel"]);
                    level.shelf.id_sheld = Convert.ToInt32(sqlDataReader["ID Estante"]);
                    level.shelf.letter = sqlDataReader["Estante"].ToString();
                    level.shelf.hall.id_hall = Convert.ToInt32(sqlDataReader["ID Pasillo"]);
                    level.shelf.hall.warehouse.idWarehouse = Convert.ToInt32(sqlDataReader["ID Bodega"]);
                    level.shelf.hall.warehouse.name = sqlDataReader["ID Bodega"].ToString();

                    list.Add(level);
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
