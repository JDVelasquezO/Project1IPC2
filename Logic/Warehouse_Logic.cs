using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Warehouse_Logic
    {
        Warehouse_Data warehouse_Data = new Warehouse_Data();

        public bool InsertWarehouse(Warehouse_Entity warehouse)
        {
            return warehouse_Data.InsertWarehouse(warehouse);
        }
    }
}
