using Entity;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class OperatorController : Controller
    {
        UserOperative_Logic userOperative = new UserOperative_Logic();
        // GET: Operator
        public ActionResult searchOperative(int id)
        {
            return PartialView(userOperative.searchOperativeById(id));
        }

        public ActionResult ChanguePassword(int id)
        {
            return View(userOperative.searchOperativeById(id));
        }

        public ActionResult UpdatePassword(String password, String password2)
        {
            UserOperative_Entity userOperativeEntity = new UserOperative_Entity();
            userOperativeEntity.id_user_operative = Convert.ToInt32(Session["operative"]);

            string script = "";

            if (password.Equals(password2))
            {
                userOperativeEntity.password = password;

                if (userOperative.updatePassword(userOperativeEntity))
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
                            "window.location.href = '/Index/HomeOperative'; " +
                         "</script>";
            }

            return Content(script);
        }
    }
}