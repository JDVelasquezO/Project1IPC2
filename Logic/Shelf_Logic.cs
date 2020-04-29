using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Shelf_Logic
    {
        Shelf_Data shelf_Data = new Shelf_Data();

        public bool InsertShelf(Shelf_Entity shelf)
        {
            return shelf_Data.InsertShelf(shelf);
        }

        public List<Shelf_Entity> getShelfsByClientBusiness(int idClientBusiness)
        {
            return shelf_Data.getShelfsByClientBusiness(idClientBusiness);
        }
    }
}
