using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Warehouse_Entity
    {
        public int idWarehouse { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public ClientBusiness_Entity clientBusiness = new ClientBusiness_Entity();
    }
}
