using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Product_Logic
    {
        Product_Data product_Data = new Product_Data();

        public List<Product_Entity> getProductsOfClient(int id)
        {
            return product_Data.getProductsOfClient(id);
        }
    }
}
