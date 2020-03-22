using DataAccess;
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
        ClientBusiness_Data clientBusiness_Data = new ClientBusiness_Data();

        public List<ClientBusiness_Entity> listClientBusiness()
        {
            return clientBusiness_Data.listClientBusiness();
        }

        public ClientBusiness_Entity searchClientBusiness(int id)
        {
            return clientBusiness_Data.searchClientBusiness(id);
        }

        public bool addClientBusiness(ClientBusiness_Entity client_business)
        {
            return clientBusiness_Data.addClientBusiness(client_business);
        }

        public bool deleteClientBusiness(int id)
        {
            return clientBusiness_Data.deleteClientBusiness(id);
        }

        public List<Contact_Entity> searchContact(int id)
        {
            return clientBusiness_Data.searchContact(id);
        }
    }
}
