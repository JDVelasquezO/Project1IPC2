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

        // INSERTAR SALDOS
        public bool addCostInboundTransactionBalance(InboundTransactionBalance inboundBalance)
        {
            bool response = false;
            float priceProduct = 0;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("insertInboundTransactionBalance", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter p_idProd = new SqlParameter();
                p_idProd.ParameterName = "@fkIdProd";
                p_idProd.SqlDbType = SqlDbType.Int;
                p_idProd.Value = inboundBalance.product.id_product;

                priceProduct = product_Data.getCostProductById(inboundBalance.product.id_product);

                SqlParameter p_idWarehouse = new SqlParameter();
                p_idWarehouse.ParameterName = "@fkIdLevel";
                p_idWarehouse.SqlDbType = SqlDbType.Int;
                p_idWarehouse.Value = inboundBalance.level.id_level;

                SqlParameter p_idProvider = new SqlParameter();
                p_idProvider.ParameterName = "@fkIdProvider";
                p_idProvider.SqlDbType = SqlDbType.Int;
                p_idProvider.Value = inboundBalance.provider.id_provider;

                SqlParameter p_quantity = new SqlParameter();
                p_quantity.ParameterName = "@quantityProd";
                p_quantity.SqlDbType = SqlDbType.Int;
                p_quantity.Value = inboundBalance.quantityProds;
                
                SqlParameter p_costProd = new SqlParameter();
                p_costProd.ParameterName = "@costProd";
                p_costProd.SqlDbType = SqlDbType.Float;
                p_costProd.Value = priceProduct;

                SqlParameter p_totalCost = new SqlParameter();
                p_totalCost.ParameterName = "@totalCost";
                p_totalCost.SqlDbType = SqlDbType.Float;
                p_totalCost.Value = inboundBalance.totalCost;
                
                sqlCommand.Parameters.Add(p_idProd);
                sqlCommand.Parameters.Add(p_idWarehouse);
                sqlCommand.Parameters.Add(p_idProvider);
                sqlCommand.Parameters.Add(p_quantity);
                sqlCommand.Parameters.Add(p_costProd);
                sqlCommand.Parameters.Add(p_totalCost);

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

        // INSERTAR LOTES
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

        public List<InboundTransaction> GetInboundTransactions(string nameProd, string nameLogic)
        {
            List<InboundTransaction> list = new List<InboundTransaction>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("getInboundTransactions", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter p_nameProd = new SqlParameter();
                p_nameProd.ParameterName = "@name_prod";
                p_nameProd.SqlDbType = SqlDbType.VarChar;
                p_nameProd.Value = nameProd;

                SqlParameter p_logic = new SqlParameter();
                p_logic.ParameterName = "@logic";
                p_logic.SqlDbType = SqlDbType.VarChar;
                p_logic.Value = nameLogic;

                sqlCommand.Parameters.Add(p_nameProd);
                sqlCommand.Parameters.Add(p_logic);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    InboundTransaction inbound = new InboundTransaction();
                    inbound.idInboundTransaction = Convert.ToInt32(sqlDataReader["id_inbound"]);
                    inbound.quantityProds = Convert.ToInt32(sqlDataReader["quantityProduct"]);
                    inbound.product.name = sqlDataReader["name_product"].ToString();
                    inbound.product.description = sqlDataReader["descripttion"].ToString();
                    inbound.logic = sqlDataReader["logic"].ToString();
                    inbound.date = sqlDataReader["date_transaction"].ToString();

                    list.Add(inbound);
                }

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }

        public List<InboundTransactionBalance> GetInboundTransactionsBalances(int id, string nameProd)
        {
            List<InboundTransactionBalance> list = new List<InboundTransactionBalance>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("get_inbound_balance", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter p_nameProd = new SqlParameter();
                p_nameProd.ParameterName = "@nameProd";
                p_nameProd.SqlDbType = SqlDbType.VarChar;
                p_nameProd.Value = nameProd;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@fkIdClientBusiness";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = id;

                sqlCommand.Parameters.Add(p_nameProd);
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

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }
    }
}
