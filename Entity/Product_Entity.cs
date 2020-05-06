using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product_Entity
    {
        public int id_product { get; set; }
        public int bar_code { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public string presentation { get; set; }
        public string description { get; set; }
        public string clasification { get; set; }
    }
}
