using Entity;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class ContactController : Controller
    {
        Contact_Logic contact_Logic = new Contact_Logic();

        public ActionResult AddContact(string cbxClientBusiness, string name_contact, string dpi_contact, string celphone_contact, string officephone_contact, string extension_contact, string email_contact, string address_contact)
        {
            Contact_Entity contact = new Contact_Entity();
            contact.name_contact = name_contact;
            contact.dpi_contact = dpi_contact;
            contact.celphone = celphone_contact;
            contact.officephone = officephone_contact;
            contact.extension = extension_contact;
            contact.address_office = address_contact;
            contact.email = email_contact;
            contact.client_business.id_client_business = Convert.ToInt32(cbxClientBusiness);

            String script = "";

            if (contact_Logic.addComercialContact(contact))
            {
                script = "<script>" +
                            "alert('Contacto Agregado Correctamente'); " +
                            "window.location.href = '/Index/Home'" +
                         "</script>";
            } else
            {
                script = "<script>" +
                        "alert('No se pudo agregar el contacto'); " +
                        "window.location.href = '/ClientBusiness/AddClientBusiness'" +
                     "</script>";
            }

            return Content(script);
        }
    }
}