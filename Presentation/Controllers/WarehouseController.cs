using Entity;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class WarehouseController : Controller
    {
        UserOperative_Logic userOperative = new UserOperative_Logic();
        Warehouse_Logic warehouse = new Warehouse_Logic();

        public ActionResult Index(int id)
        {
            int idClientBusiness = userOperative.getIdClientBusiness(id);
            return PartialView(userOperative.getWarehouseOfClient(idClientBusiness));
        }

        public ActionResult InsertWarehouse(int idOperative, string name_warehouse, string desc_warehouse, string address_warehouse)
        {
            Warehouse_Entity warehouse_Entity = new Warehouse_Entity();

            int idClientBusiness = userOperative.getIdClientBusiness(idOperative);

            warehouse_Entity.name = name_warehouse;
            warehouse_Entity.description = desc_warehouse;
            warehouse_Entity.address = address_warehouse;
            warehouse_Entity.clientBusiness.id_client_business = idClientBusiness;

            if (warehouse.InsertWarehouse(warehouse_Entity))
            {
                return Content("<script>" +
                                    "alert('Registro Insertado Correctamente');" +
                                "</script>");
            } else {
                return Content("<script>" +
                                    "alert('No se pudo ingresar');" +
                                    "window.location.href='/Inventory/Index';" +
                                "</script>");
            }
        }
    }
}