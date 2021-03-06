﻿using Entity;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class HallController : Controller
    {
        UserOperative_Logic userOperative = new UserOperative_Logic();
        Warehouse_Logic warehouse = new Warehouse_Logic();
        Hall_Logic hall_Logic = new Hall_Logic();

        List<Warehouse_Entity> list_warehouses = new List<Warehouse_Entity>();
        // GET: Hall
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateHall(int idOperative)
        {
            int idClientBusiness = userOperative.getIdClientBusiness(idOperative);
            list_warehouses = userOperative.getWarehouseOfClient(idClientBusiness);
            ViewBag.ListTypeBusiness = list_warehouses;
            return View();
        }

        public ActionResult InsertHall(int cbxIdWarehouse, int no_hall, float width_hall, float length_hall)
        {
            Hall_Entity hall = new Hall_Entity();

            hall.warehouse.idWarehouse = cbxIdWarehouse;
            hall.no_hall = no_hall;
            hall.width = width_hall;
            hall.length = length_hall;

            if (hall_Logic.InsertHall(hall))
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