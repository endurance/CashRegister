using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using CashRegister.Core.Service;
using CashRegisterMVC.Models.Inventory;

namespace CashRegisterMVC.Controllers.Inventory
{
    public class CashRegisterWebApi
    {
        public string UrlParameters { get; set; }
        private string BaseUrl = "http://localhost:59162/";

        public CashRegisterWebApi()
        {
        }

        public CashRegisterWebApi(string url)
        {
            BaseUrl = url;
        }

        public IEnumerable<ItemResponse> Get(string urlParameters)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                return response.Content.ReadAsAsync<IEnumerable<ItemResponse>>().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return null;
        }    
    }

    [RoutePrefix("items")]
    public class ItemController : Controller
    {
        private readonly IItemService _service;
        public CashRegisterWebApi CashRegisterApi { get; set; }
        public ItemController(IItemService service)
        {
            _service = service;
            CashRegisterApi = new CashRegisterWebApi();
        }

        // GET: Item
        [Route("")]
        public ActionResult ViewAll()
        {
            //// Get all the items that I have
            //var allItems = _service.GetAllWithInventoryCounts();
            //// turn them into their view models.
            //var vmList = (from kvp in allItems
            //    let item = kvp.Key
            //    let inventory = kvp.Value
            //    select new ItemResponse {ItemData = item, TotalInventory = inventory}).ToList();

            var responses = CashRegisterApi.Thing1();

            return View(responses);
        }

        [Route("{itemId:guid}")]
        public ActionResult ViewSingle(Guid itemId)
        {
            var item = _service.Get(itemId);
            var vm = new ItemResponse {ItemData = item};
            return View(vm);
        }

        [Route("itemVariation/{itemId:guid}")]
        public ActionResult ViewItemVariation(Guid itemId)
        {
            //return RedirectToRoute($"ItemVariation/ListVariationsOfAnItem/?itemId={itemId}");
            return RedirectToAction("ListVariationsOfAnItem", "ItemVariationApi", new {itemId});
        }
    }
}