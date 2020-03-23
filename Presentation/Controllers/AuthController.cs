using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class AuthController : Controller
    {
        Contact_Logic contact_Logic = new Contact_Logic();

        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string pass)
        {
            var script = "";
            string emailContact = "";
            string passContact = "";
            int idContact = 0;

            foreach (var item in contact_Logic.returnCredentials())
            {
                emailContact = item.email;
                passContact = item.password;

                if (email == emailContact && pass == passContact)
                {
                    idContact = item.id_contact;
                    break;
                }
            }

            if (email == "admin@gmail.com" && pass == "1234567")
            {
                script = "<script languaje='javascript'>" +
                         "window.location.href='/Index/Home'; " +
                         "</script>";

                Session["user"] = email;

            }
            else if (email == emailContact && pass == passContact)
            {
                script = "<script languaje='javascript'>" +
                             "window.location.href='/Index/HomeContact'; " +
                         "</script>";

                Session["contact"] = idContact;
            }
            else
            {
                script = "<script languaje='javascript'>" +
                         "alert('Las credensiales son incorrectas');" +
                         "window.location.href='/Auth/Login'; " +
                         "</script>";
            }

            return Content(script);
        }

        public void Logout()
        {
            Session["user"] = null;
            Response.Redirect("/Index/Home");
        }
    }
}