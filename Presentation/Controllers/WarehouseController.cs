using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class WarehouseController : Controller
    {
        UserOperative_Logic userOperative = new UserOperative_Logic();
        // GET: Warehouse
        public ActionResult Index(int id)
        {
            return PartialView(userOperative.getWarehouseOfClient(id));
        }
    }
}