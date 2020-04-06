using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UserOperative_Entity
    {
        public int id_user_operative { get; set; }
        public string name_operative { get; set; }
        public string job { get; set; }
        public string celphone { get; set; }
        public string password { get; set; }
        public bool status { get; set; }
        public AdminServices_Entity adminServices = new AdminServices_Entity();
    }
}
