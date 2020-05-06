using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Cost_Logic
    {
        Cost_Data costData = new Cost_Data();

        public bool addCostInboundTransaction(InboundTransaction inbound)
        {
            return costData.addCostInboundTransaction(inbound);
        }
    }
}
