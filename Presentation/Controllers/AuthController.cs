using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string pass)
        {
            var script = "";

            if (email == "admin@gmail.com" && pass == "1234567")
            {
                script = "<script languaje='javascript'>" +
                         "window.location.href='/Index/Home'; " +
                         "</script>";

                Session["user"] = email;

            } else
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