﻿using System;
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
    }
}