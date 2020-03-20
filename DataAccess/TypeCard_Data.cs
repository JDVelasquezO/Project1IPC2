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
    public class TypeCard_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public List<TypeCard_Entity> listTypeCard()
        {
            List<TypeCard_Entity> list = new List<TypeCard_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("list_type_card", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    TypeCard_Entity type_card = new TypeCard_Entity();
                    type_card.id_type_card = Convert.ToInt32(sqlDataReader["Identificador"]);
                    type_card.type_card = sqlDataReader["Nombre Tarjeta"].ToString();

                    list.Add(type_card);
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
