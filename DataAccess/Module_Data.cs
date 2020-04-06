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
    public class Module_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public List<TypeModule_Entity> listTypeModule()
        {
            List<TypeModule_Entity> list = new List<TypeModule_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("list_type_module", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    TypeModule_Entity type = new TypeModule_Entity();
                    type.id_type_module = Convert.ToInt32(sqlDataReader["Identificador"]);
                    type.type_module = sqlDataReader["Tipo"].ToString();

                    list.Add(type);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }

        public List<Module_Entity> listModule()
        {
            List<Module_Entity> list = new List<Module_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("list_modules", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Module_Entity module = new Module_Entity();
                    module.id_module = Convert.ToInt32(sqlDataReader["Identificador"]);
                    module.name_module = sqlDataReader["Nombre Modulo"].ToString();
                    module.abb_module = sqlDataReader["Abreviacion"].ToString();
                    module.desc_module = sqlDataReader["Descripcion"].ToString();
                    module.is_default = Convert.ToBoolean(sqlDataReader["Es default"]);
                    module.status_mode = Convert.ToBoolean(sqlDataReader["Estado"]);
                    module.typeModule.id_type_module = Convert.ToInt32(sqlDataReader["ID Tipo Modulo"]);

                    list.Add(module);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }

        public Module_Entity searchModule(int id)
        {
            Module_Entity module = new Module_Entity();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("search_module", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idModule";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = id;

                sqlCommand.Parameters.Add(id_parameter);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();

                if (sqlDataReader.HasRows)
                {
                    module.id_module = Convert.ToInt32(sqlDataReader["Identificador"]);
                    module.name_module = sqlDataReader["Nombre Modulo"].ToString();
                    module.abb_module = sqlDataReader["Abreviacion"].ToString();
                    module.desc_module = sqlDataReader["Descripcion"].ToString();
                    module.is_default = Convert.ToBoolean(sqlDataReader["Es default"]);
                    module.status_mode = Convert.ToBoolean(sqlDataReader["Estado"]);
                    module.typeModule.type_module = sqlDataReader["Tipo Modulo"].ToString();
                }

            }
            catch (Exception e)
            {
                throw;
            }

            return module;
        }

        public bool changueStatusModule(Module_Entity module)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("change_status_module", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idModule";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = module.id_module;

                SqlParameter p_status = new SqlParameter();
                p_status.ParameterName = "@statusModule";
                p_status.SqlDbType = SqlDbType.Bit;
                p_status.Value = module.status_mode;

                sqlCommand.Parameters.Add(id_parameter);
                sqlCommand.Parameters.Add(p_status);

                sqlCommand.ExecuteNonQuery();

                response = true;
            }
            catch (Exception e)
            {
                throw;
            }

            return response;
        }

        public List<Module_Entity> listModuleOfContact(int id)
        {
            List<Module_Entity> list = new List<Module_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("search_module_contact", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idModule";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = id;

                sqlCommand.Parameters.Add(id_parameter);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Module_Entity module = new Module_Entity();
                    module.id_module = Convert.ToInt32(sqlDataReader["Identificador"]);
                    module.name_module = sqlDataReader["Nombre Modulo"].ToString();
                    module.abb_module = sqlDataReader["Abreviacion"].ToString();
                    module.desc_module = sqlDataReader["Descripcion"].ToString();
                    module.is_default = Convert.ToBoolean(sqlDataReader["Es default"]);
                    module.status_mode = Convert.ToBoolean(sqlDataReader["Estado"]);
                    module.clientBusiness.name_client_business = sqlDataReader["Nombre Cliente"].ToString();
                    module.typeModule.type_module = sqlDataReader["Tipo Modulo"].ToString();

                    list.Add(module);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }

        public bool addModule(Module_Entity module)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("add_module", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter p_name = new SqlParameter();
                p_name.ParameterName = "@name_module";
                p_name.SqlDbType = SqlDbType.VarChar;
                p_name.Size = 20;
                p_name.Value = module.name_module;

                SqlParameter p_abbreviation = new SqlParameter();
                p_abbreviation.ParameterName = "@abbreviation";
                p_abbreviation.SqlDbType = SqlDbType.VarChar;
                p_abbreviation.Size = 10;
                p_abbreviation.Value = module.abb_module;

                SqlParameter p_description = new SqlParameter();
                p_description.ParameterName = "@description";
                p_description.SqlDbType = SqlDbType.VarChar;
                p_description.Size = 100;
                p_description.Value = module.desc_module;

                SqlParameter p_idTypeModule = new SqlParameter();
                p_idTypeModule.ParameterName = "@idTypeModule";
                p_idTypeModule.SqlDbType = SqlDbType.Int;
                p_idTypeModule.Value = module.typeModule.id_type_module;

                sqlCommand.Parameters.Add(p_name);
                sqlCommand.Parameters.Add(p_abbreviation);
                sqlCommand.Parameters.Add(p_description);
                sqlCommand.Parameters.Add(p_idTypeModule);

                sqlCommand.ExecuteNonQuery();

                response = true;
            }
            catch (Exception e)
            {
                throw;
            }

            return response;
        }
    }
}
