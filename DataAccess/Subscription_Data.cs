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
                    subscription.typeModule.type_module = sqlDataReader["Tipo Modulo"].ToString();
                    subscription.typeSubscription.type_subscription = sqlDataReader["Tipo Suscripcion"].ToString();
                    subscription.typeSubscription.init_date = sqlDataReader["Fecha Inicial"].ToString();
                    subscription.typeSubscription.finish_date = sqlDataReader["Fecha Final"].ToString();
                    subscription.clientBusiness.name_client_business = sqlDataReader["Cliente"].ToString();
                    subscription.typeModule.id_type_module = Convert.ToInt32(sqlDataReader["ID Tipo Modulo"]);
                    subscription.typeSubscription.id_type_subscription = Convert.ToInt32(sqlDataReader["ID Tipo Suscription"]);
                    subscription.clientBusiness.id_client_business = Convert.ToInt32(sqlDataReader["ID Cliente"]);

                    list.Add(subscription);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }

        public List<Subscription_Entity> searchSubscription(int id)
        {
            List<Subscription_Entity> list = new List<Subscription_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("search_subscription", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idClientBusiness";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = id;

                sqlCommand.Parameters.Add(id_parameter);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Subscription_Entity subscription = new Subscription_Entity();
                    subscription.id_subscription = Convert.ToInt32(sqlDataReader["Identificador"]);
                    subscription.typeModule.type_module = sqlDataReader["Tipo Modulo"].ToString();
                    subscription.typeSubscription.type_subscription = sqlDataReader["Tipo Suscripcion"].ToString();
                    subscription.typeSubscription.init_date = sqlDataReader["Fecha Inicial"].ToString();
                    subscription.typeSubscription.finish_date = sqlDataReader["Fecha Final"].ToString();
                    subscription.clientBusiness.name_client_business = sqlDataReader["Cliente"].ToString();
                    subscription.typeModule.id_type_module = Convert.ToInt32(sqlDataReader["ID Tipo Modulo"]);
                    subscription.typeSubscription.id_type_subscription = Convert.ToInt32(sqlDataReader["ID Tipo Suscription"]);
                    subscription.clientBusiness.id_client_business = Convert.ToInt32(sqlDataReader["ID Cliente"]);

                    list.Add(subscription);
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
