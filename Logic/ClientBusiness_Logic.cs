using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ClientBusiness_Logic
    {
        ClientBusiness_Logic clientBusiness_Logic = new ClientBusiness_Logic();

        public List<ClientBusiness_Entity> listClientBusiness()
        {
            return clientBusiness_Logic.listClientBusiness();
        }
    }
}
