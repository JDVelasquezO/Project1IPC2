using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AdminServices_Entity
    {
        public int id_admin_services { get; set; }
        public string password { get; set; }
        public ClientBusiness_Entity clientBusiness = new ClientBusiness_Entity();
    }
}
