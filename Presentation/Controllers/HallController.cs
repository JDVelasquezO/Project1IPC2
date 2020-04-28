using Entity;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class HallController : Controller
    {
        UserOperative_Logic userOperative = new UserOperative_Logic();
        Warehouse_Logic warehouse = new Warehouse_Logic();

        List<Warehouse_Entity> list_warehouses = new List<Warehouse_Entity>();
        // GET: Hall
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateHall(int idOperative)
        {
            int idClientBusiness = userOperative.getIdClientBusiness(idOperative);
            list_warehouses = userOperative.getWarehouseOfClient(idClientBusiness);
            ViewBag.ListTypeBusiness = list_warehouses;
            return View();
        }
    }
}