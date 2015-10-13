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
    public class ItemApiController : ApiController
    {
        private IItemService ItemService { get; set; }

        public ItemApiController(IItemService itemService)
        {
            ItemService = itemService;
        }
        [ResponseType(typeof(IEnumerable<ItemResponse>))]
        public IHttpActionResult Get()
        {
            var items = ItemService.GetAll();
            var itemResponses = items.Select(item => new ItemResponse(item));
            return Ok(itemResponses);
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