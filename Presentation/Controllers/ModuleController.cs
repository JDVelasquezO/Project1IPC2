using Entity;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class ModuleController : Controller
    {
        Module_Logic module_Logic = new Module_Logic();

        public ActionResult ListModule()
        {
            return PartialView(module_Logic.listModule());
        }

        public ActionResult EditModules(int id)
        {
            return View(module_Logic.searchModule(id));
        }

        public ActionResult ChanguePassword(string id, string status)
        {
            Module_Entity module = new Module_Entity();
            module.id_module = Convert.ToInt32(id);
            module.status_mode = Convert.ToBoolean(status);

            String script = "";

            if (module_Logic.changueStatusModule(module))
            {
                script = "<script languaje='javascript'>" +
                            "window.location.href='/Module/EditModules/"+id+"'; " +
                            "</script>";
            }
            else
            {
                script = "<script languaje='javascript'>" +
                            "alert('Registro no actualizado'); " +
                            "</script>";
            }

            return Content(script);
        }

        public ActionResult SearchModuleOfContact(int id)
        {
            return PartialView(module_Logic.listModuleOfContact(id));
        }
    }
}