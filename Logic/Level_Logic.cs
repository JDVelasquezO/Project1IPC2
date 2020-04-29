using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Level_Logic
    {
        Level_Data logic_Data = new Level_Data();

        public bool InsertShelf(Level_Entity level)
        {
            return logic_Data.InsertLevel(level);
        }
    }
}
