﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Contact_Entity
    {
        public int id_contact { get; set; }
        public string name_contact { get; set; }
        public string dpi_contact { get; set; }
        public string celphone { get; set; }
        public string officephone { get; set; }
        public string extension { get; set; }
        public string email { get; set; }
        public string address_office { get; set; }
        public string password { get; set; }
        public TypeContact_Entity typeContact = new TypeContact_Entity();
        public ClientBusiness_Entity client_business = new ClientBusiness_Entity();
        public AdminServices_Entity adminServices = new AdminServices_Entity();
    }
}
