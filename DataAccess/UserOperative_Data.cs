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
                    operative.email = sqlDataReader["Email"].ToString();

                    list.Add(operative);
                }

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }

        public List<UserOperative_Entity> returnCredentials()
        {
            List<UserOperative_Entity> list = new List<UserOperative_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("return_credentials_operative", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    UserOperative_Entity userOperative = new UserOperative_Entity();
                    userOperative.id_user_operative = Convert.ToInt32(sqlDataReader["Identificador"]);
                    userOperative.name_operative = sqlDataReader["Nombre"].ToString();
                    userOperative.job = sqlDataReader["Puesto"].ToString();
                    userOperative.email = sqlDataReader["Email"].ToString();
                    userOperative.celphone = sqlDataReader["Celular"].ToString();
                    userOperative.password = sqlDataReader["Password"].ToString();

                    list.Add(userOperative);
                }

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }

        public UserOperative_Entity searchOperativeById(int id)
        {
            UserOperative_Entity userOperative = new UserOperative_Entity();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("returnOperativeById", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idOperative";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = id;

                sqlCommand.Parameters.Add(id_parameter);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();

                if (sqlDataReader.HasRows)
                {
                    userOperative.id_user_operative = Convert.ToInt32(sqlDataReader["Identificador"]);
                    userOperative.name_operative = sqlDataReader["Nombre"].ToString();
                    userOperative.job = sqlDataReader["Puesto"].ToString();
                    userOperative.email = sqlDataReader["Email"].ToString();
                    userOperative.celphone = sqlDataReader["Celular"].ToString();
                    userOperative.password = sqlDataReader["Password"].ToString();
                }

                sqlConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }

            return userOperative;
        }

        public bool updatePassword(UserOperative_Entity userOperative)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("update_pass_operative", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idOperative";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = userOperative.id_user_operative;

                SqlParameter p_password = new SqlParameter();
                p_password.ParameterName = "@Password";
                p_password.SqlDbType = SqlDbType.VarChar;
                p_password.Size = 20;
                p_password.Value = userOperative.password;

                sqlCommand.Parameters.Add(id_parameter);
                sqlCommand.Parameters.Add(p_password);

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

        public int getIdClientBusiness(int idOperative)
        {
            int idClientBusiness = 0;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("return_idclientbusiness", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idOperative";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = idOperative;

                sqlCommand.Parameters.Add(id_parameter);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();

                if (sqlDataReader.HasRows)
                {
                    idClientBusiness = Convert.ToInt32(sqlDataReader["Identificador"]);
                }

                sqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return idClientBusiness;
        }

        public List<Warehouse_Entity> getWarehouseOfClient(int id)
        {
            List<Warehouse_Entity> list = new List<Warehouse_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("return_warehouse", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idClientBusiness";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = id;

                sqlCommand.Parameters.Add(id_parameter);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Warehouse_Entity warehouse = new Warehouse_Entity();
                    warehouse.idWarehouse = Convert.ToInt32(sqlDataReader["Identificador"]);
                    warehouse.name = sqlDataReader["Nombre"].ToString();
                    warehouse.description = sqlDataReader["Descripcion"].ToString();
                    warehouse.idInventory = Convert.ToInt32(sqlDataReader["Inventario"]);
                    warehouse.address = sqlDataReader["Direccion"].ToString();

                    list.Add(warehouse);
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
