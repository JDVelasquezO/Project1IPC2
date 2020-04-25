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
        UserOperative_Logic userOperative = new UserOperative_Logic();

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

            string emailOperative = "";
            string passOperative = "";

            int idContact = 0;
            int idOperative = 0;
            int idRol = 0;

            foreach (var item in contact_Logic.returnCredentials())
            {
                emailContact = item.email;
                passContact = item.password;

                if (email == emailContact && pass == passContact)
                {
                    idContact = item.id_contact;
                    idRol = item.typeContact.id_typecontact;
                    break;
                }
            }

            foreach (var item in userOperative.returnCredentials())
            {
                emailOperative = item.email;
                passOperative = item.password;

                if (email == emailOperative && pass == passOperative)
                {
                    idOperative = item.id_user_operative;
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
                Session["adminContact"] = idContact;

                script = "<script languaje='javascript'>" +
                            "window.location.href='/Index/HomeContact'; " +
                            "</script>";
            }
            else if (email == emailOperative && pass == passOperative)
            {
                Session["operative"] = idOperative;

                script = "<script languaje='javascript'>" +
                            "window.location.href='/Index/HomeOperative'; " +
                         "</script>";
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
