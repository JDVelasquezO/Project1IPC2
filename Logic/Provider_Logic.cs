using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Provider_Logic
    {
        Provider_Data provider_Data = new Provider_Data();

        public List<Provider_Entity> getLevelsByClientBusiness()
        {
            return provider_Data.getLevelsByClientBusiness();
        }
    }
}
