using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class TypeCard_Logic
    {
        TypeCard_Data typeCard_Data = new TypeCard_Data();

        public List<TypeCard_Entity> listTypeCard()
        {
            return typeCard_Data.listTypeCard();
        }
    }
}
