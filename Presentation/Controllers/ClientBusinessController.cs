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
            return View(clientBusiness_Logic.searchClientBusiness(id));
        }
    }
}