using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class ModuleController : Controller
    {
        Module_Logic module_Logic = new Module_Logic();

        public ActionResult ListModule()
        {
            return PartialView(module_Logic.listModule());
        }
    }
}