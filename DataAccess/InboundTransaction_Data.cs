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
    public class InboundTransaction_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public bool SellProducts(string logic, string name_prod, int quantity)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();

                if (logic == "PEPS")
                {
                    sqlCommand = new SqlCommand("TransferOut", sqlConnection);
                }
                else
                {
                    sqlCommand = new SqlCommand("TransferOutlotUEPS", sqlConnection);
                }

                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter p_logic = new SqlParameter();
                p_logic.ParameterName = "@logic";
                p_logic.SqlDbType = SqlDbType.VarChar;
                p_logic.Value = logic;

                SqlParameter p_name = new SqlParameter();
                p_name.ParameterName = "@name_prod";
                p_name.SqlDbType = SqlDbType.VarChar;
                p_name.Value = name_prod;

                SqlParameter p_quantity = new SqlParameter();
                p_quantity.ParameterName = "@quantityToSell";
                p_quantity.SqlDbType = SqlDbType.Int;
                p_quantity.Value = quantity;

                sqlCommand.Parameters.Add(p_name);
                sqlCommand.Parameters.Add(p_logic);
                sqlCommand.Parameters.Add(p_quantity);

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
