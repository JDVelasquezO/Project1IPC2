using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class BalanceController : Controller
    {
        InboundTransactionBalance_Logic balance = new InboundTransactionBalance_Logic();
        // GET: Balance
        public ActionResult SellProducts(int quantity, int id)
        {
            string script = "";

            if (balance.sellProducts(quantity, id))
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