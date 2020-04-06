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
    public class Subscription_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public List<Subscription_Entity> listSubscription()
        {
            List<Subscription_Entity> list = new List<Subscription_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("list_subscriptions", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Subscription_Entity subscription = new Subscription_Entity();
                    subscription.id_subscription = Convert.ToInt32(sqlDataReader["Identificador"]);
                    subscription.clientBusiness.name_client_business = sqlDataReader["Nombre Cliente"].ToString();
                    subscription.type_subscription = sqlDataReader["Tipo Suscripcion"].ToString();

                    list.Add(subscription);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }

        public List<Module_Subscription_Entity> searchSubscription(int id)
        {
            List<Module_Subscription_Entity> list = new List<Module_Subscription_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("list_subscription_of_client", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idClientBusiness";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = id;

                sqlCommand.Parameters.Add(id_parameter);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Module_Entity> list_module = new List<Module_Entity>();

                while (sqlDataReader.Read())
                {
                    Module_Subscription_Entity module_subscription = new Module_Subscription_Entity();
                    module_subscription.subscription.type_subscription = sqlDataReader["Tipo Suscripcion"].ToString();
                    module_subscription.module.name_module = sqlDataReader["Nombre Modulo"].ToString();
                    module_subscription.module.quetzals = sqlDataReader["Precio Q"].ToString();
                    module_subscription.module.dollars = sqlDataReader["Precio D"].ToString();

                    list.Add(module_subscription);
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
