using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Subscription_Entity
    {
        public int id_subscription { get; set; }
        public string type_subscription { get; set; }
        public string init_date { get; set; }
        public string finish_date { get; set; }
        public ClientBusiness_Entity clientBusiness = new ClientBusiness_Entity();
    }
}
