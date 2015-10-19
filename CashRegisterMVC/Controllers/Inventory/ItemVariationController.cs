using System;
using System.Linq;
using System.Web.Mvc;
using CashRegister.Core.Service;
using CashRegisterMVC.Models.Inventory;
namespace CashRegisterMVC.Controllers.Inventory
{
    [Route("item/variation")]
    public class ItemVariationController : Controller
    {
        private readonly IItemVariationService _service;

        public ItemVariationController(IItemVariationService service)
        {
            _service = service;
        }
        [Route("{id:guid}")]
        // GET: ItemVariation
        public ActionResult ListVariationsOfAnItem(Guid itemId)
        {
            var variations = _service.GetAllVariationsBasedOnItemKey(itemId);
            var vms = variations.Select(i => new ItemVariationResponse() {Variation = i});
            return View(vms);
        }
    }
}