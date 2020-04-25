using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            if (Session["user"] == null)
            {
                return Content("<script>" +
                                    "alert('Sesion Expirada'); " +
                                    "window.location.href='/Auth/Login' " +
                                "</script>");
            } else
            {
                return View();
            }
        }

        public ActionResult HomeContact()
        {
            if (Session["adminContact"] == null)
            {
                return Content("<script>" +
                                    "alert('Sesion Expirada'); " +
                                    "window.location.href='/Auth/Login' " +
                                "</script>");
            }
            else
            {
                return View();
            }
        }

        public ActionResult ComercialContact()
        {
            if (Session["comercialContact"] == null)
            {
                return Content("<script>" +
                                    "alert('Sesion Expirada'); " +
                                    "window.location.href='/Auth/Login' " +
                                "</script>");
            }
            else
            {
                return View();
            }
        }

        public ActionResult FinanceContact()
        {
            if (Session["financeContact"] == null)
            {
                return Content("<script>" +
                                    "alert('Sesion Expirada'); " +
                                    "window.location.href='/Auth/Login' " +
                                "</script>");
            }
            else
            {
                return View();
            }
        }

        public ActionResult HomeOperative()
        {
            if (Session["operative"] == null)
            {
                return Content("<script>" +
                                    "alert('Sesion Expirada'); " +
                                    "window.location.href='/Auth/Login' " +
                                "</script>");
            }
            else
            {
                return View();
            }
        }
    }
}