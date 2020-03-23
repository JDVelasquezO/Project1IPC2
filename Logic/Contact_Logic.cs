using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Contact_Logic
    {
        Contact_Data contact_Data = new Contact_Data();

        /*public Contact_Entity searchClientBusiness(int id)
        {
            return contact_Data.searchContact(id);
        }*/

        public Contact_Entity searchComercialContact(int id)
        {
            return contact_Data.searchComercialContact(id);
        }

        public bool addComercialContact(Contact_Entity contact)
        {
            return contact_Data.addComercialContact(contact);
        }

        public bool addFinanceContact(Contact_Entity contact)
        {
            return contact_Data.addFinanceContact(contact);
        }

        public int returnIdAdminServices()
        {
            return contact_Data.returnIdAdminServices();
        }

        public bool addAdminServices(AdminServices_Entity adminServices)
        {
            return contact_Data.addAdminServices(adminServices);
        }

        public bool addAdminServicesContact(Contact_Entity contact)
        {
            return contact_Data.addAdminServicesContact(contact);
        }

        public List<Contact_Entity> returnCredentials()
        {
            return contact_Data.returnCredentials();
        }
    }
}
