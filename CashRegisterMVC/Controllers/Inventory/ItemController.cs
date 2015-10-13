using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CashRegister.Core.Service;
using CashRegisterMVC.Models.Inventory;
using Services;
using StructureMap;

namespace CashRegisterMVC.Controllers.Inventory
{
    [RoutePrefix("items")]
    public class ItemController : Controller
    {
        private readonly IItemService _service;

        public ItemController(IItemService service)
        {
            _service = service;
        }

        // GET: Item
        [Route("")]
        public ActionResult ViewAll()
        {
            // Get all the items that I have
            var allItems = _service.GetAllWithInventoryCounts();
            // turn them into their view models.
            List<ItemResponse> vmList = (from kvp in allItems
                                          let item = kvp.Key
                                          let inventory = kvp.Value
                                          select new ItemResponse(item) {TotalInventory = inventory}).ToList();

            return View(vmList);
        }
        [Route("{itemId:guid}")]
        public ActionResult ViewSingle(Guid itemId)
        {
            var item = _service.Get(itemId);
            var vm = new ItemResponse(item);
            return View(vm);
        }
        [Route("itemVariation/{itemId:guid}")]
        public ActionResult ViewItemVariation(Guid itemId)
        {
            //return RedirectToRoute($"ItemVariation/ListVariationsOfAnItem/?itemId={itemId}");
            return RedirectToAction("ListVariationsOfAnItem", "ItemVariation", new { itemId });
        }
    }
}