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

        List<TypeModule_Entity> list_type_business = new List<TypeModule_Entity>();

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

        public ActionResult AddModules()
        {
            list_type_business = module_Logic.listTypeModule();
            ViewBag.list_type_business = list_type_business;

            return View();
        }

        public ActionResult InsertModule(string module_name, string abreviation, string description, string cbxModule)
        {
            String script = "";

            Module_Entity module = new Module_Entity();
            module.name_module = module_name;
            module.abb_module = abreviation;
            module.desc_module = description;
            module.typeModule.id_type_module = Convert.ToInt32(cbxModule);

            if (module_Logic.addModule(module))
            {
                script = "<script languaje='javascript'>" +
                            "alert('Modulo agregado correctamente'); " +
                            "window.location.href = '/Index/Home'; " +
                         "</script>";
            }
            else
            {
                script = "<script languaje='javascript'>" +
                            "alert('No se pudo agregar');" +
                            "window.location.href = '/ClientBusiness/AddClientBusiness'; " +
                         "</script>";
            }

            return Content(script);
        }
    }
}