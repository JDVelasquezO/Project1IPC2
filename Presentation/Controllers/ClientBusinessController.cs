using Entity;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class ClientBusinessController : Controller
    {
        ClientBusiness_Logic clientBusiness_Logic = new ClientBusiness_Logic();
        Contact_Logic contact_Logic = new Contact_Logic();

        List<TypeBusiness_Entity> list_type_business = new List<TypeBusiness_Entity>();
        TypeBusiness_Logic typeBusiness_Logic = new TypeBusiness_Logic();

        List<SizeBusiness_Entity> list_size_business = new List<SizeBusiness_Entity>();
        SizeBusiness_Logic size_business_Logic = new SizeBusiness_Logic();

        List<TypeCard_Entity> list_type_card = new List<TypeCard_Entity>();
        TypeCard_Logic typeCard_Logic = new TypeCard_Logic();

        List<CreditCard_Entity> list_credit_card = new List<CreditCard_Entity>();
        CreditCard_Logic creditCard_Logic = new CreditCard_Logic();

        /*List<Contact_Entity> list_contact = new List<Contact_Entity>();
        Contact_Logic contact_Logic = new Contact_Logic();*/

        // GET: ClientBusiness
        public ActionResult ListClientBusiness()
        {
            if (Session["user"] == null)
            {
                return Content("<script>" +
                                    "alert('Sesion Expirada'); " +
                                    "window.location.href='/Auth/Login' " +
                                "</script>");
            }
            else
            {
                return PartialView(clientBusiness_Logic.listClientBusiness());
            }
        }

        public ActionResult EditClientBusiness(int id)
        {
            if (Session["user"] == null)
            {
                return Content("<script>" +
                                    "alert('Sesion Expirada'); " +
                                    "window.location.href='/Auth/Login' " +
                                "</script>");
            }
            else
            {
                list_type_business = typeBusiness_Logic.listTypeBusiness();
                ViewBag.ListTypeBusiness = list_type_business;

                list_size_business = size_business_Logic.listSizeBusiness();
                ViewBag.ListSizeBusiness = list_size_business;

                list_type_card = typeCard_Logic.listTypeCard();
                ViewBag.ListTypeCard = list_type_card;

                return View(clientBusiness_Logic.searchClientBusiness(id));
            }
        }

        public ActionResult AddClientBusiness()
        {
            list_type_business = typeBusiness_Logic.listTypeBusiness();
            ViewBag.ListTypeBusiness = list_type_business;

            list_size_business = size_business_Logic.listSizeBusiness();
            ViewBag.ListSizeBusiness = list_size_business;

            list_type_card = typeCard_Logic.listTypeCard();
            ViewBag.ListTypeCard = list_type_card;

            list_credit_card = creditCard_Logic.listCreditCard();
            ViewBag.ListCreditCard = list_credit_card;

            return View();
        }

        public ActionResult InsertClientBusiness(string business_name, string nit_business, string quantEmployees, string cbxTypeBusiness, string cbxCreditCard)
        {
            String script = "";
            int quantity = Convert.ToInt32(quantEmployees);

            ClientBusiness_Entity client_business = new ClientBusiness_Entity();
            client_business.name_client_business = business_name;
            client_business.nit = nit_business;
            client_business.quantity_employees = quantity;
            client_business.typeBusiness_Entity.id_type_business = Convert.ToInt32(cbxTypeBusiness);
            client_business.creditCard_Entity.id_credit_card = Convert.ToInt32(cbxCreditCard);

            if (quantity >= 1 && quantity <= 10)
            {
                client_business.sizeBusiness_Entity.id_size_business = 1;
            }
            else if (quantity >= 11 && quantity <= 15)
            {
                client_business.sizeBusiness_Entity.id_size_business = 2;
            }
            else if (quantity >= 16 && quantity <= 25)
            {
                client_business.sizeBusiness_Entity.id_size_business = 3;
            }
            else if (quantity >= 25 && quantity <= 40)
            {
                client_business.sizeBusiness_Entity.id_size_business = 4;
            }
            else if (quantity >= 41 && quantity <= 50)
            {
                client_business.sizeBusiness_Entity.id_size_business = 5;
            }
            else if (quantity > 50)
            {
                client_business.sizeBusiness_Entity.id_size_business = 6;
            }

            if (clientBusiness_Logic.addClientBusiness(client_business))
            {
                script = "<script languaje='javascript'>" +
                            "alert('Cliente agregado correctamente'); " +
                            "window.location.href = '/Index/Home'; " +
                         "</script>";
            }
            else
            {
                script = "<script languaje='javascript'>" +
                            "alert('No se pudo agregar');" +
                            "window.location.href = '/ClientBusiness/AddClientBusiness'; " +
                         "</script>";
            }

            return Content(script);
        }

        public ActionResult DeleteClientBusiness(int idClientBusiness)
        {
            string script = "";

            if (clientBusiness_Logic.deleteClientBusiness(idClientBusiness))
            {
                script = "<script languaje='javascript'>" +
                            "alert('Registro eliminado correctamente');" +
                            "window.location.href='/Index/Home';" +
                         "</script>";
            }

            return Content(script);
        }

        public ActionResult InfoContact(int idClientBusiness)
        {
            return View(clientBusiness_Logic.searchContact(idClientBusiness));
        }
    }
}