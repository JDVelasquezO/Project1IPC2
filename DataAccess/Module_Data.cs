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
                    module.clientBusiness.id_client_business = Convert.ToInt32(sqlDataReader["ID Cliente"]);
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
    }
}
