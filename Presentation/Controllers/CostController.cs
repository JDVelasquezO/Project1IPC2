using Entity;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Presentation.Controllers
{
    public class CostController : Controller
    {
        UserOperative_Logic userOperative = new UserOperative_Logic();
        Product_Logic product_Logic = new Product_Logic();
        Level_Logic level_Logic = new Level_Logic();
        Provider_Logic provider_Logic = new Provider_Logic();
        Cost_Logic cost_Logic = new Cost_Logic();
        Warehouse_Logic warehouse_Logic = new Warehouse_Logic();
        
        List<Product_Entity> list_products = new List<Product_Entity>();
        List<Level_Entity> list_levels = new List<Level_Entity>();
        List<Provider_Entity> list_providers = new List<Provider_Entity>();
        List<Warehouse_Logic> list_warehouses = new List<Warehouse_Logic>();

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

        public ActionResult TakeLot(int id)
        {
            int idClientBusiness = userOperative.getIdClientBusiness(id);

            list_products = product_Logic.getProductsOfClient(idClientBusiness);
            ViewBag.ListProducts = list_products;

            return View();
        }

        public string getLot(string nameProd, string nameLogic)
        {
            var list_lots = cost_Logic.GetInboundTransactions(nameProd, nameLogic);
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(list_lots);
            return json;
        }

        public ActionResult InsertCost(string selectLevel, string selectProd, string quantity, 
            string quantityLots, string costTotal, string selectLogic, string selectProvider)
        {
            string script = "";

            InboundTransaction inboundTransaction = new InboundTransaction();
            inboundTransaction.product.id_product = Convert.ToInt32(selectProd);
            inboundTransaction.level.id_level = Convert.ToInt32(selectProd);
            inboundTransaction.provider.id_provider = Convert.ToInt32(selectProvider);
            inboundTransaction.quantityProds = Convert.ToInt32(quantity);
            inboundTransaction.quantityLots = Convert.ToInt32(quantityLots);
            inboundTransaction.totalCost = float.Parse(costTotal);
            inboundTransaction.logic = selectLogic;

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

        public ActionResult InsertCostBalance(string selectLevel, string selectProd, string quantity,
            string costTotal, string selectLogic, string selectProvider)
        {
            string script = "";

            InboundTransactionBalance inboundTransactionBalance = new InboundTransactionBalance();
            inboundTransactionBalance.product.id_product = Convert.ToInt32(selectProd);
            inboundTransactionBalance.level.id_level = Convert.ToInt32(selectProd);
            inboundTransactionBalance.provider.id_provider = Convert.ToInt32(selectProvider);
            inboundTransactionBalance.quantityProds = Convert.ToInt32(quantity);
            inboundTransactionBalance.totalCost = float.Parse(costTotal);
            inboundTransactionBalance.logic = selectLogic;

            if (cost_Logic.addCostInboundTransactionBalance(inboundTransactionBalance))
            {
                script = "<script>alert('Se ingreso correctamente');</script>";
            }
            else
            {
                script = "<script>alert('No se ingreso');</script>";
            }

            return Content(script);
        }

        public ActionResult AddCostBalance(int id)
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
   
    }
}