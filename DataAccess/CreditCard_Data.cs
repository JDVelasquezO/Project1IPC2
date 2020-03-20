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

        public List<CreditCard_Entity> listTypeCard()
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
    }
}
