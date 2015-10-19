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
    public class ItemVariationApiController : ApiController
    {
        public ItemVariationApiController(IItemVariationService itemVariationService)
        {
            ItemVariationService = itemVariationService;
        }

        private IItemVariationService ItemVariationService { get; }

        [Route("{itemId}/variations")]
        [ResponseType(typeof (IEnumerable<ItemVariationResponse>))]
        [HttpGet]
        public IHttpActionResult GetAllVariationsFromItem(Guid itemId)
        {
            var variations = ItemVariationService.GetAllVariationsBasedOnItemKey(itemId);
            // Convert
            var responses = variations.Select(v => new ItemVariationResponse {Variation = v}).ToList();
            return Ok(responses);
        }

        [Route("{itemId:guid}/variations/{variationId:guid}")]
        [ResponseType(typeof (ItemVariationResponse))]
        [HttpGet]
        public IHttpActionResult GetVariation(Guid itemId, Guid variationId)
        {
            var itemVariation = ItemVariationService.Get(variationId);
            // Convert
            var response = new ItemVariationResponse {Variation = itemVariation};
            return Ok(response);
        }

        [Route("{itemId:guid}/variations")]
        [ResponseType(typeof (Guid))]
        [HttpPost]
        public IHttpActionResult CreateVariation(Guid itemId, [FromBody] ItemVariation variation)
        {
            ItemVariationService.Insert(variation);
            return Ok(variation.Id);
        }

        [Route("{itemId:guid}/variations")]
        [ResponseType(typeof (Guid))]
        [HttpPut]
        public IHttpActionResult UpdateVariation(Guid itemId, [FromBody] ItemVariation variation)
        {
            ItemVariationService.Update(variation);
            return Ok(variation.Id);
        }

        [Route("{itemId:guid}/variations/{variationId:guid}")]
        [ResponseType(typeof (Guid))]
        [HttpDelete]
        public IHttpActionResult DeleteVariation(Guid itemId, Guid variationId)
        {
            ItemVariationService.Delete(variationId);
            return Ok(variationId);
        }
    }
}