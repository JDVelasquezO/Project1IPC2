using Entity;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class CreditCardController : Controller
    {
        CreditCard_Logic creditCard_Logic = new CreditCard_Logic();
        
        public ActionResult InsertCreditCard(int cbxTypeCard, string number_card, string name_card, string date_expiration, int crv)
        {
            CreditCard_Entity credit_card = new CreditCard_Entity();
            credit_card.number_card = number_card;
            credit_card.name_card = name_card;
            credit_card.date_expiration = date_expiration;
            credit_card.crv = crv;
            credit_card.typeCard_Entity.id_type_card = cbxTypeCard;

            String script = "";

            if (creditCard_Logic.addCreditCard(credit_card))
            {
                script = "<script languaje='javascript'>" +
                            "alert('Tarjeta agregada correctamente'); " +
                            "window.location.href = '/ClientBusiness/AddClientBusiness'; " +
                         "</script>";
            }
            else
            {
                script = "<script languaje='javascript'>" +
                            "alert('No se pudo agregar')" +
                            "window.location.href = '/ClientBusiness/AddClientBusiness'; " +
                         "</script>";
            }

            return Content(script);
        }
    }
}