using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class InboundTransactionBalance
    {
        public int idInboundTransaction { get; set; }
        public int quantityProds { get; set; }
        public float totalCost { get; set; }
        public string date { get; set; }
        public Product_Entity product = new Product_Entity();
        public Level_Entity level = new Level_Entity();
        public Provider_Entity provider = new Provider_Entity();
    }
}
