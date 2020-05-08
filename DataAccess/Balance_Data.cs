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
    public class Balance_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public List<InboundTransactionBalance> getInboundBalance(int id)
        {
            List<InboundTransactionBalance> list = new List<InboundTransactionBalance>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("get_inbound_balance", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@fkIdClientBusiness";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = id;

                sqlCommand.Parameters.Add(id_parameter);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    InboundTransactionBalance balance = new InboundTransactionBalance();
                    balance.idInboundTransaction = Convert.ToInt32(sqlDataReader["Identificador"]);
                    balance.quantityProds = Convert.ToInt32(sqlDataReader["Cantidad"]);
                    balance.product.name = sqlDataReader["Nombre"].ToString();
                    balance.product.description = sqlDataReader["Descripcion"].ToString();
                    balance.level.id_level = Convert.ToInt32(sqlDataReader["Nivel"]);
                    balance.level.shelf.letter = sqlDataReader["Estante"].ToString();
                    balance.level.shelf.hall.id_hall = Convert.ToInt32(sqlDataReader["Pasillo"]);
                    balance.level.shelf.hall.warehouse.name = sqlDataReader["Bodega"].ToString();

                    list.Add(balance);
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
