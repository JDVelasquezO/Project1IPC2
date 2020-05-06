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
    public class Product_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public float getCostProductById(int id)
        {
            float price = 0;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand($"SELECT price FROM product WHERE id_product = {id}", sqlConnection);
                
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    price = float.Parse(sqlDataReader["price"].ToString());
                }

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return price;
        }
        
        public List<Product_Entity> getProductsOfClient(int id)
        {
            List<Product_Entity> list = new List<Product_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("return_productByClient", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idClientBusiness";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = id;

                sqlCommand.Parameters.Add(id_parameter);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Product_Entity product = new Product_Entity();
                    product.id_product = Convert.ToInt32(sqlDataReader["Identificador"]);
                    product.bar_code = Convert.ToInt32(sqlDataReader["Codigo de Barras"]);
                    product.name = sqlDataReader["Nombre"].ToString();
                    product.description = sqlDataReader["Descripcion"].ToString();
                    product.clasification = sqlDataReader["Clasificacion"].ToString();
                    product.price = float.Parse(sqlDataReader["Precio"].ToString());

                    list.Add(product);
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
