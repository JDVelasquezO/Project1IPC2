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
    public class Shelf_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public List<Shelf_Entity> getShelfsByClientBusiness(int idClientBusiness)
        {
            List<Shelf_Entity> list = new List<Shelf_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("get_shelfs_byIdClientBusiness", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idClientBusiness";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = idClientBusiness;

                sqlCommand.Parameters.Add(id_parameter);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Shelf_Entity shelf = new Shelf_Entity();
                    shelf.id_sheld = Convert.ToInt32(sqlDataReader["Identificador"]);
                    shelf.letter = sqlDataReader["Nombre"].ToString();

                    list.Add(shelf);
                }

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }

        public bool InsertShelf(Shelf_Entity shelf)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("add_shelf", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter p_name = new SqlParameter();
                p_name.ParameterName = "@name_shelf";
                p_name.SqlDbType = SqlDbType.VarChar;
                p_name.Value = shelf.letter;

                SqlParameter p_width = new SqlParameter();
                p_width.ParameterName = "@width";
                p_width.SqlDbType = SqlDbType.Int;
                p_width.Value = 5;

                SqlParameter p_length = new SqlParameter();
                p_length.ParameterName = "@length";
                p_length.SqlDbType = SqlDbType.Int;
                p_length.Value = 10;

                SqlParameter p_height = new SqlParameter();
                p_height.ParameterName = "@height";
                p_height.SqlDbType = SqlDbType.Int;
                p_height.Value = shelf.heigth;

                SqlParameter fkIdHall = new SqlParameter();
                fkIdHall.ParameterName = "@fkIdHall";
                fkIdHall.SqlDbType = SqlDbType.Int;
                fkIdHall.Value = shelf.hall.id_hall;

                sqlCommand.Parameters.Add(p_name);
                sqlCommand.Parameters.Add(p_width);
                sqlCommand.Parameters.Add(p_length);
                sqlCommand.Parameters.Add(p_height);
                sqlCommand.Parameters.Add(fkIdHall);

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
