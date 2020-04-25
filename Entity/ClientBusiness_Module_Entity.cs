using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ClientBusiness_Module_Entity
    {
        public int id_clientBusiness_module { get; set; }
        public ClientBusiness_Entity clientBusiness = new ClientBusiness_Entity();
        public Module_Entity module = new Module_Entity();
    }
}
