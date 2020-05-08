using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class InboundTransactionBalance_Logic
    {
        Balance_Data balance = new Balance_Data();

        public List<InboundTransactionBalance> getInboundBalance(int id)
        {
            return balance.getInboundBalance(id);
        }
    }
}
