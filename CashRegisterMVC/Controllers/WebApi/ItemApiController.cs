using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using CashRegister.Core.Models;
using CashRegister.Core.Service;
using CashRegisterMVC.Models.Inventory;

namespace CashRegisterMVC.Controllers.WebApi
{
    [RoutePrefix("api/items")]
    public class ItemApiController : ApiController
    {
        private IItemService ItemService { get; }

        public ItemApiController(IItemService itemService)
        {
            ItemService = itemService;
        }
        [Route("")]
        [ResponseType(typeof(IEnumerable<ItemResponse>))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            // Service Call
            var allItems = ItemService.GetAllWithInventoryCounts();
            
            // Conversion
            List<ItemResponse> itemReponses = (from kvp in allItems
                                                let item = kvp.Key
                                                let inventory = kvp.Value
                                                select new ItemResponse() { ItemData = item, TotalInventory = inventory }).ToList();
            return Ok(itemReponses);
        }

        [Route("{id:guid}")]
        [ResponseType(typeof (ItemResponse))]
        [HttpGet]
        public IHttpActionResult Get(Guid id)
        {
            var itemDictionary = ItemService.GetWithInventoryCount(id);

            //Conversion
            var itemResponse = (from kvp in itemDictionary
                let item = kvp.Key
                let inventory = kvp.Value
                select new ItemResponse() { ItemData = item, TotalInventory = inventory}).First();

            return Ok(itemResponse);
        }
        [HttpPut]
        public IHttpActionResult Create(Guid id, [FromBody]Item value)
        {
            if(ItemService.Get(id) != null) return InternalServerError();
            ItemService.Insert(value);
            return Ok("Item Inserted");
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            var item = ItemService.Get(id);
            if (item == null) return InternalServerError();
            ItemService.Delete(id);
            return Ok("Item Deleted");
        }
    }
}