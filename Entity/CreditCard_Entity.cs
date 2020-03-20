using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CreditCard_Entity
    {
        public int id_credit_card { get; set; }
        public string number_card { get; set; }
        public string name_card { get; set; }
        public string date_expiration { get; set; }
        public int crv { get; set; }
        public TypeCard_Entity typeCard_Entity = new TypeCard_Entity();
    }
}
