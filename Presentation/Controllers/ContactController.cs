using Entity;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// Librerias para correo electronico
using System.Text;
using System.Net.Mail;
using System.Net;

namespace Presentation.Controllers
{
    public class ContactController : Controller
    {
        Contact_Logic contact_Logic = new Contact_Logic();
        Subscription_Logic subscription = new Subscription_Logic();

        public ActionResult functionForAddContact(bool condition)
        {
            String script = "";

            if (condition)
            {
                script = "<script>" +
                            "alert('Contacto Agregado Correctamente'); " +
                            "window.location.href = '/Index/Home'" +
                         "</script>";
            }
            else
            {
                script = "<script>" +
                        "alert('No se pudo agregar el contacto'); " +
                        "window.location.href = '/ClientBusiness/AddClientBusiness'" +
                     "</script>";
            }

            return Content(script);
        }

        public ActionResult AddComercialContact(string cbxClientBusiness, string name_contact, string dpi_contact, string celphone_contact, string officephone_contact, string extension_contact, string email_contact, string address_contact)
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

            return this.functionForAddContact(contact_Logic.addComercialContact(contact));
        }

        public ActionResult AddFinanceContact(string cbxClientBusiness, string name_contact, string dpi_contact, string celphone_contact, string officephone_contact, string extension_contact, string email_contact, string address_contact)
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

            return this.functionForAddContact(contact_Logic.addFinanceContact(contact));
        }

        public ActionResult AddAdminServices(string cbxClientBusiness)
        {
            AdminServices_Entity admin_services = new AdminServices_Entity();
            admin_services.clientBusiness.id_client_business = Convert.ToInt32(cbxClientBusiness);

            string script = "";

            if (contact_Logic.addAdminServices(admin_services))
            {
                script = "<script languaje = 'javascript' > " +
                            "alert('Se registró correctamente');" +
                         "</script>";
            }
            else
            {
                script = "<script languaje='javascript'>" +
                            "alert('Administrador NO se pudo agregar');" +
                         "</script>";
            }

            return Content(script);
        }

        public ActionResult AddAdminServicesContact(string cbxClientBusiness, string name_contact, string dpi_contact, string celphone_contact, string officephone_contact, string extension_contact, string email_contact, string address_contact)
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
            contact.adminServices.id_admin_services = contact_Logic.returnIdAdminServices();

            return this.functionForAddContact(contact_Logic.addAdminServicesContact(contact));
        }

        public ActionResult SearchComercialContact(int id)
        {
            return PartialView(contact_Logic.searchContact(id));
        }

        public ActionResult ChanguePassword(int id)
        {
            return View(contact_Logic.searchContact(id));
        }

        public ActionResult UpdatePassword (String password, String password2)
        {
            Contact_Entity contact = new Contact_Entity();
            contact.id_contact = Convert.ToInt32(Session["adminContact"]);

            string script = "";

            if (password.Equals(password2))
            {
                contact.password = password;

                if (contact_Logic.updatePassword(contact))
                {
                    script = "<script>" +
                                "alert('Las contraseña se actualizo. Debes iniciar Sesión');" +
                                "window.location.href = '/Auth/Login'; " +
                             "</script>";
                }
            }
            else
            {
                script = "<script>" +
                            "alert('Las contraseñas no coinciden');" +
                            "window.location.href = '/Index/HomeContact'; " +
                         "</script>";
            }

            return Content(script);
        }

        public ActionResult SearchSubscription(int id)
        {
            return View(subscription.searchSubscription(id));
        }
    }
}