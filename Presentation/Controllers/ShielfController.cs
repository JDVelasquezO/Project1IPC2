using Entity;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class ShielfController : Controller
    {
        UserOperative_Logic userOperative = new UserOperative_Logic();
        Hall_Logic hall_Logic = new Hall_Logic();
        Shelf_Logic shelf_Logic = new Shelf_Logic();

        List<Hall_Entity> list_halls = new List<Hall_Entity>();

        // GET: Shielf
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateShielf(int idOperative)
        {
            int idClientBusiness = userOperative.getIdClientBusiness(idOperative);
            list_halls = hall_Logic.getHallsByClientBusiness(idClientBusiness);
            ViewBag.ListHalls = list_halls;

            return View();
        }

        public ActionResult InsertShielf(string letter_shielf, float heigth_shielf, int cbxIdShelf)
        {
            Shelf_Entity shelf = new Shelf_Entity();

            shelf.hall.id_hall = cbxIdShelf;
            shelf.letter = letter_shielf;
            shelf.heigth = heigth_shielf;

            if (shelf_Logic.InsertShelf(shelf))
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