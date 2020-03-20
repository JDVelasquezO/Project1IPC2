using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ClientBusiness_Entity
    {
        public int id_client_business { get; set; }
        public string nit { get; set; }
        public string name_client_business { get; set; }
        public int quantity_employees { get; set; }
        public CreditCard_Entity creditCard_Entity = new CreditCard_Entity();
        public SizeBusiness_Entity sizeBusiness_Entity = new SizeBusiness_Entity();
        public TypeBusiness_Entity typeBusiness_Entity = new TypeBusiness_Entity();
        public TypeCard_Entity typeCard_Entity = new TypeCard_Entity();
    }
}
