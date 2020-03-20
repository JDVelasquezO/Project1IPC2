using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class ClientBusinessController : Controller
    {
        ClientBusiness_Logic clientBusiness_Logic = new ClientBusiness_Logic();
        
        // GET: ClientBusiness
        public ActionResult ListClientBusiness()
        {
            return PartialView(clientBusiness_Logic.listClientBusiness());
        }
    }
}