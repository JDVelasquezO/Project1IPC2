using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Module_Subscription_Entity
    {
        public int id_module_subscription { get; set; }
        public Subscription_Entity subscription = new Subscription_Entity();
        public Module_Entity module = new Module_Entity();
    }
}
