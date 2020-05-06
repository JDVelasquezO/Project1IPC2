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
    public class Cost_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;
        Product_Data product_Data = new Product_Data();

        public bool addCostInboundTransaction(InboundTransaction inbound)
        {
            bool response = false;
            float priceProduct = 0;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("insertInboundTransaction", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter p_idProd = new SqlParameter();
                p_idProd.ParameterName = "@fkIdProd";
                p_idProd.SqlDbType = SqlDbType.Int;
                p_idProd.Value = inbound.product.id_product;

                priceProduct = product_Data.getCostProductById(inbound.product.id_product);

                SqlParameter p_idWarehouse = new SqlParameter();
                p_idWarehouse.ParameterName = "@fkIdLevel";
                p_idWarehouse.SqlDbType = SqlDbType.Int;
                p_idWarehouse.Value = inbound.level.id_level;

                SqlParameter p_idProvider = new SqlParameter();
                p_idProvider.ParameterName = "@fkIdProvider";
                p_idProvider.SqlDbType = SqlDbType.Int;
                p_idProvider.Value = inbound.provider.id_provider;

                SqlParameter p_quantity = new SqlParameter();
                p_quantity.ParameterName = "@quantityProd";
                p_quantity.SqlDbType = SqlDbType.Int;
                p_quantity.Value = inbound.quantityProds;

                SqlParameter p_quantityLots = new SqlParameter();
                p_quantityLots.ParameterName = "@quantityLots";
                p_quantityLots.SqlDbType = SqlDbType.Int;
                p_quantityLots.Value = inbound.quantityLots;

                SqlParameter p_costProd = new SqlParameter();
                p_costProd.ParameterName = "@costProd";
                p_costProd.SqlDbType = SqlDbType.Float;
                p_costProd.Value = priceProduct;

                SqlParameter p_totalCost = new SqlParameter();
                p_totalCost.ParameterName = "@totalCost";
                p_totalCost.SqlDbType = SqlDbType.Float;
                p_totalCost.Value = inbound.totalCost;

                SqlParameter p_logic = new SqlParameter();
                p_logic.ParameterName = "@logic";
                p_logic.SqlDbType = SqlDbType.VarChar;
                p_logic.Value = inbound.logic;

                sqlCommand.Parameters.Add(p_idProd);
                sqlCommand.Parameters.Add(p_idWarehouse);
                sqlCommand.Parameters.Add(p_idProvider);
                sqlCommand.Parameters.Add(p_quantity);
                sqlCommand.Parameters.Add(p_quantityLots);
                sqlCommand.Parameters.Add(p_costProd);
                sqlCommand.Parameters.Add(p_totalCost);
                sqlCommand.Parameters.Add(p_logic);

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
