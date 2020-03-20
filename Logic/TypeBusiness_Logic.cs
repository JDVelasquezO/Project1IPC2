using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class TypeBusiness_Logic
    {
        TypeBusiness_Data typeBusiness_Data = new TypeBusiness_Data();

        public List<TypeBusiness_Entity> listTypeCard()
        {
            return typeBusiness_Data.listTypeCard();
        }
    }
}
