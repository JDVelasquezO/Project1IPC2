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
        Product_Logic product_Logic = new Product_Logic();
        Level_Logic level_Logic = new Level_Logic();
        Provider_Logic provider_Logic = new Provider_Logic();
        Cost_Logic cost_Logic = new Cost_Logic();
        
        List<Product_Entity> list_products = new List<Product_Entity>();
        List<Level_Entity> list_levels = new List<Level_Entity>();
        List<Provider_Entity> list_providers = new List<Provider_Entity>();

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

            list_providers = provider_Logic.getLevelsByClientBusiness();
            ViewBag.ListProviders = list_providers;

            list_products = product_Logic.getProductsOfClient(idClientBusiness);
            ViewBag.ListProducts = list_products;

            return View();
        }
        
        public ActionResult InsertCost(string selectLevel, string selectProd, string quantity, 
            string quantityLots, string costTotal, string selectLogic, string selectProvider,
            string selectTransaction)
        {
            string script = "";

            InboundTransaction inboundTransaction = new InboundTransaction();
            if (selectTransaction == "Entrada")
            {
                inboundTransaction.product.id_product = Convert.ToInt32(selectProd);
                inboundTransaction.level.id_level = Convert.ToInt32(selectProd);
                inboundTransaction.provider.id_provider = Convert.ToInt32(selectProvider);
                inboundTransaction.quantityProds = Convert.ToInt32(quantity);
                inboundTransaction.quantityLots = Convert.ToInt32(quantityLots);
                inboundTransaction.totalCost = float.Parse(costTotal);
                inboundTransaction.logic = selectLogic;
            }

            if (cost_Logic.addCostInboundTransaction(inboundTransaction))
            {
                script = "<script>alert('Se ingreso correctamente');</script>";
            }
            else
            {
                script = "<script>alert('No se ingreso');</script>";
            }

            return Content(script);
        }

        public ActionResult ChooseHall()
        {
            return View();
        }
    }
}