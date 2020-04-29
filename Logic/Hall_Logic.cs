using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Hall_Logic
    {
        Hall_Data hall_Data = new Hall_Data();

        public bool InsertHall(Hall_Entity hall)
        {
            return hall_Data.InsertHall(hall);
        }

        public List<Hall_Entity> getHallsByClientBusiness(int idClientBusiness)
        {
            return hall_Data.getHallsByClientBusiness(idClientBusiness);
        }
    }
}
