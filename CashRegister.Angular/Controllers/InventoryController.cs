using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashRegister.Angular.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult InventoryManagement()
        {
            return View();
        }
    }
}