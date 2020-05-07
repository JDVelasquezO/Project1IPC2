using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class InboundTransaction_Logic
    {
        InboundTransaction_Data inbound = new InboundTransaction_Data();

        public bool SellProducts(string logic, string name_prod, int quantity)
        {
            return inbound.SellProducts(logic, name_prod, quantity);
        }
    }
}
