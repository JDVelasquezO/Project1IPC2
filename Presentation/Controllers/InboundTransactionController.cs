using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class InboundTransactionController : Controller
    {
        InboundTransaction_Logic inboundTransaction = new InboundTransaction_Logic();

        // GET: InboundTransaction
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SellProducts(string logic, string name, int quantityToSell)
        {
            string script = "";

            if (inboundTransaction.SellProducts(logic, name, quantityToSell))
            {
                return Redirect("/Inventory/Index");
            }
            else
            {
                script = "<script>alert('Productos No Vendidos');</script>";
            }

            return Content(script);
        }
    }
}