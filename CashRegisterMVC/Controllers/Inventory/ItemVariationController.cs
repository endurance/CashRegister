using System;
using System.Linq;
using System.Web.Mvc;
using CashRegisterMVC.Models.Inventory;
using Services;

namespace CashRegisterMVC.Controllers.Inventory
{
    public class ItemVariationController : Controller
    {
        private readonly ItemVariationService _service = new ItemVariationService();
        // GET: ItemVariation
        public ActionResult ListVariationsOfAnItem(Guid itemId)
        {
            var variations = _service.GetAllVariationsBasedOnItemKey(itemId);
            var vms = variations.Select(i => new ItemVariationViewModel(i));
            return View(vms);
        }
    }
}