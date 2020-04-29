using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Hall_Entity
    {
        public int id_hall { get; set; }
        public int no_hall { get; set; }
        public float width { get; set; }
        public float length { get; set; }
        public string dimensions { get; set; }
        public Warehouse_Entity warehouse = new Warehouse_Entity();
    }
}
