using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CashRegisterMVC.Models.Inventory;
using Services;

namespace CashRegisterMVC.Controllers.Inventory
{
    public class ItemController : Controller
    {
        private readonly ItemService _service = new ItemService();
        // GET: Item
        public ActionResult ViewItems()
        {
            // Get all the items that I have
            var allItems = _service.GetAll();
            // turn them into their view models.
            List<ItemViewModel> vms = allItems.Select(i => new ItemViewModel(i)).ToList();
            return View(vms);
        }
    }
}