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

        List<Warehouse_Entity> list_warehouses = new List<Warehouse_Entity>();
        List<Product_Entity> list_products = new List<Product_Entity>();

        // GET: Cost
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCost(int id)
        {
            int idClientBusiness = userOperative.getIdClientBusiness(id);

            list_warehouses = userOperative.getWarehouseOfClient(idClientBusiness);
            ViewBag.ListWarehouses = list_warehouses;

            list_products = product_Logic.getProductsOfClient(idClientBusiness);
            ViewBag.ListProducts = list_products;

            return View();
        }
    }
}