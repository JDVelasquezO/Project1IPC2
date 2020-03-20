using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SizeBusiness_Logic
    {
        SizeBusiness_Data sizeBusiness_Data = new SizeBusiness_Data();

        public List<SizeBusiness_Entity> listTypeCard()
        {
            return sizeBusiness_Data.listTypeCard();
        }
    }
}
