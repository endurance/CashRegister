using System.Collections.Generic;
using System.Web.Mvc;

namespace CashRegisterWebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Inventory()
        {
            return View();
        }

        [Authorize]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult CountInventory()
        {
            //TODO:Add the stuff to allow inventory counting
            return View();
        }

        public ActionResult AddItem()
        {
            //TODO: add the stuff to add a new item to the inventory
            return View();
        }
    }
}