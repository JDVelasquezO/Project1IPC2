using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Price_Entity
    {
        public int id_price { get; set; }
        public string range_users { get; set; }
        public string quetzals { get; set; }
        public string dollars { get; set; }
        public TypeModule_Entity typeModule = new TypeModule_Entity();
        public TypeSubscription_Entity typeSubscription = new TypeSubscription_Entity();
    }
}
