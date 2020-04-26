using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class InventoryController : Controller
    {
        UserOperative_Logic userOperative = new UserOperative_Logic();
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LookWarehouse(int id)
        {
            return View(userOperative.getIdClientBusiness(id));
        }
    }
}
