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
    }
}