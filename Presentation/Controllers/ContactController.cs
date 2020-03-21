using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult InfoContact()
        {
            return View();
        }
    }
}