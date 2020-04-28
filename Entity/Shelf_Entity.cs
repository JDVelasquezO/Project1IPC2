using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Shelf_Entity
    {
        public int id_sheld { get; set; }
        public string letter { get; set; }
        public float heigth { get; set; }
        public float width { get; set; }
        public float length { get; set; }
        public Hall_Entity hall = new Hall_Entity();
    }
}
