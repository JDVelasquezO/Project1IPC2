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

        [HttpPost]
        public ActionResult SendMail()
        {
            try
            {
                //Configuración del Mensaje
                MailMessage mail = new MailMessage();
                //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
                mail.From = new MailAddress("jdvela158@gmail.com", "ERP", Encoding.UTF8);
            
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //Aquí ponemos el asunto del correo
                mail.Subject = "Prueba de Envío de Correo";
                //Aquí ponemos el mensaje que incluirá el correo
                mail.Body = "Prueba de Envío de Correo de Gmail desde CSharp";
                //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
                mail.To.Add("Kgabyortiz1@gmail.com");

                //Configuracion del SMTP
                SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
                //Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential("jdvela158@gmail.com", "DiosesAmor123");
                SmtpServer.EnableSsl = true;
                SmtpServer.Host = "smptp.gmail.com";
                SmtpServer.Send(mail);
                return Content("<script>alert('Se envio el email')</script>");
            }
            catch (Exception ex)
            {
                return Content("<script>alert('No se envio el email')</script>");
            }
        }
    }
}