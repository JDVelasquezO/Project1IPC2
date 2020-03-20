using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CreditCard_Logic
    {
        CreditCard_Data creditCard_Data = new CreditCard_Data();

        public List<CreditCard_Entity> listTypeCard()
        {
            return creditCard_Data.listTypeCard();
        }
    }
}
