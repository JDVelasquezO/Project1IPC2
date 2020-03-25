using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class SubscriptionController : Controller
    {
        Subscription_Logic subscription_Logic = new Subscription_Logic();

        public ActionResult ListSubscriptions()
        {
            return View(subscription_Logic.listSubscription());
        }
    }
}