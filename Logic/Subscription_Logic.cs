using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Subscription_Logic
    {
        Subscription_Data subscription_Data = new Subscription_Data();

        public List<Subscription_Entity> listSubscription()
        {
            return subscription_Data.listSubscription();
        }

        public List<Module_Subscription_Entity> searchSubscription(int id)
        {
            return subscription_Data.searchSubscription(id);
        }
    }
}
