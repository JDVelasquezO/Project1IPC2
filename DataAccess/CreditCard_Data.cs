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
    public class CreditCard_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public List<CreditCard_Entity> listCreditCard()
        {
            List<CreditCard_Entity> list = new List<CreditCard_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("list_credit_card", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    CreditCard_Entity credit_card = new CreditCard_Entity();
                    credit_card.id_credit_card = Convert.ToInt32(sqlDataReader["Identificador"]);
                    credit_card.number_card = sqlDataReader["Numero Tarjeta"].ToString();
                    credit_card.name_card = sqlDataReader["Nombre Tarjeta"].ToString();
                    credit_card.date_expiration = sqlDataReader["Fecha Expiracion"].ToString();

                    list.Add(credit_card);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }

        public bool addCreditCard(CreditCard_Entity credit_card)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("add_credit_card", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter p_idTypeCard = new SqlParameter();
                p_idTypeCard.ParameterName = "@idTypeCard";
                p_idTypeCard.SqlDbType = SqlDbType.Int;
                p_idTypeCard.Value = credit_card.typeCard_Entity.id_type_card;

                SqlParameter p_numberCard = new SqlParameter();
                p_numberCard.ParameterName = "@numberCard";
                p_numberCard.SqlDbType = SqlDbType.VarChar;
                p_numberCard.Size = 25;
                p_numberCard.Value = credit_card.number_card;

                SqlParameter p_nameCard = new SqlParameter();
                p_nameCard.ParameterName = "@nameCard";
                p_nameCard.SqlDbType = SqlDbType.VarChar;
                p_nameCard.Size = 30;
                p_nameCard.Value = credit_card.name_card;

                SqlParameter p_crv = new SqlParameter();
                p_crv.ParameterName = "@crv";
                p_crv.SqlDbType = SqlDbType.Int;
                p_crv.Value = credit_card.crv;

                SqlParameter p_dayExpiration = new SqlParameter();
                p_dayExpiration.ParameterName = "@dateExpiration";
                p_dayExpiration.SqlDbType = SqlDbType.VarChar;
                p_dayExpiration.Size = 20;
                p_dayExpiration.Value = credit_card.date_expiration;

                sqlCommand.Parameters.Add(p_idTypeCard);
                sqlCommand.Parameters.Add(p_numberCard);
                sqlCommand.Parameters.Add(p_nameCard);
                sqlCommand.Parameters.Add(p_crv);
                sqlCommand.Parameters.Add(p_dayExpiration);

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
