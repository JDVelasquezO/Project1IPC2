using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Module_Entity
    {
        public int id_module { get; set; }
        public string name_module { get; set; }
        public string abb_module { get; set; }
        public string desc_module { get; set; }
        public bool is_default { get; set; }
        public bool status_mode { get; set; }
        public string quetzals { get; set; }
        public string dollars { get; set; }
        public TypeModule_Entity typeModule = new TypeModule_Entity();
        public ClientBusiness_Entity clientBusiness = new ClientBusiness_Entity();
    }
}
