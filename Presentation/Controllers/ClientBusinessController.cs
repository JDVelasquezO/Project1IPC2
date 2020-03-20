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
                List<TypeBusiness_Entity> list_type_business = new List<TypeBusiness_Entity>();
                TypeBusiness_Logic typeBusiness_Logic = new TypeBusiness_Logic();
                list_type_business = typeBusiness_Logic.listTypeBusiness();
                ViewBag.ListTypeBusiness = list_type_business;

                List<SizeBusiness_Entity> list_size_business = new List<SizeBusiness_Entity>();
                SizeBusiness_Logic size_business_Logic = new SizeBusiness_Logic();
                list_size_business = size_business_Logic.listSizeBusiness();
                ViewBag.ListSizeBusiness = list_size_business;

                List<TypeCard_Entity> list_type_card = new List<TypeCard_Entity>();
                TypeCard_Logic typeCard_Logic = new TypeCard_Logic();
                list_type_card = typeCard_Logic.listTypeCard();
                ViewBag.ListTypeCard = list_type_card;

                return View(clientBusiness_Logic.searchClientBusiness(id));
            }
        }

        public ActionResult AddClientBusiness()
        {
            return View();
        }
    }
}