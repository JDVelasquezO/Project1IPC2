using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Level_Entity
    {
        public int id_level { get; set; }
        public float height { get; set; }
        public Shelf_Entity shelf = new Shelf_Entity();
    }
}
