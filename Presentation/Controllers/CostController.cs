using Entity;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class CostController : Controller
    {
        UserOperative_Logic userOperative = new UserOperative_Logic();
        Warehouse_Logic warehouse = new Warehouse_Logic();
        Product_Logic product_Logic = new Product_Logic();
        Level_Logic level_Logic = new Level_Logic();

        List<Warehouse_Entity> list_warehouses = new List<Warehouse_Entity>();
        List<Product_Entity> list_products = new List<Product_Entity>();
        List<Level_Entity> list_levels = new List<Level_Entity>();

        // GET: Cost
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCost(int id)
        {
            int idClientBusiness = userOperative.getIdClientBusiness(id);

            list_levels = level_Logic.getLevelsByClientBusiness(idClientBusiness);
            ViewBag.ListLevels = list_levels;

            /*list_warehouses = userOperative.getWarehouseOfClient(idClientBusiness);
            ViewBag.ListWarehouses = list_warehouses;*/

            list_products = product_Logic.getProductsOfClient(idClientBusiness);
            ViewBag.ListProducts = list_products;

            return View();
        }

        public ActionResult ChooseHall()
        {
            return View();
        }
    }
}