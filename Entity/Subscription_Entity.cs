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
        public TypeModule_Entity typeModule = new TypeModule_Entity();
        public TypeSubscription_Entity typeSubscription = new TypeSubscription_Entity();
        public ClientBusiness_Entity clientBusiness = new ClientBusiness_Entity();
    }
}
