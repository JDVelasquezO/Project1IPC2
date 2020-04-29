using Entity;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class LevelController : Controller
    {
        UserOperative_Logic userOperative = new UserOperative_Logic();
        Hall_Logic hall_Logic = new Hall_Logic();
        Shelf_Logic shelf_Logic = new Shelf_Logic();
        Level_Logic level_Logic = new Level_Logic();

        List<Shelf_Entity> list_shelfs = new List<Shelf_Entity>();
        // GET: Level
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateLevels(int idOperative)
        {
            int idClientBusiness = userOperative.getIdClientBusiness(idOperative);
            list_shelfs = shelf_Logic.getShelfsByClientBusiness(idClientBusiness);
            ViewBag.ListShelfs = list_shelfs;

            return View();
        }

        public ActionResult InsertLevel(int cbxIdShelf)
        {
            Level_Entity level = new Level_Entity();
            
            level.shelf.id_sheld = cbxIdShelf;

            if (level_Logic.InsertShelf(level))
            {
                return Content("<script>alert('Agregado Correctamente');</script>");
            }
            else
            {
                return Content("<script>alert('No se pudo agregar');</script>");
            }
        }
    }
}