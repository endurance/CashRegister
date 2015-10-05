using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using CashRegister.Core.Models;
using CashRegisterMVC.Models;
using CashRegisterMVC.Models.Inventory;
using Services;

namespace CashRegisterMVC.Controllers
{
    public class InventoryController : Controller
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;

        private readonly StoreItemService _service = new StoreItemService(connectionString);
        // GET: Checkout
        public ActionResult Index()
        {
            var allItems = _service.GetAllItems();
            var itemInventoryDictionary = _service.GetInventoryPerItem();
            List<ItemViewModel> itemViewModels = allItems.Select(item => new ItemViewModel(item) {TotalInventory = itemInventoryDictionary[item.ItemId]}).ToList();
            return View(itemViewModels);
        }

        // GET: Checkout/Details/5
        public ActionResult ItemVariationDetails(Guid id)
        {
            // get all store items for a certain item id
            var storeItems = _service.GetAllStoreItemsWithId(id);
            var viewModels = storeItems.Select(i => new StoreItemViewModel() {StoreItem = i});
            return View(viewModels);
        }

        // GET: Checkout/Create
        public ActionResult CreateAnItem()
        {
            return View();
        }

        // POST: Checkout/Create
        [HttpPost]
        public ActionResult CreateAnItem(FormCollection collection)
        {
            try
            {
                var dict = ConvertFormCollectionIntoDictionary(collection);
                _service.InsertItem(dict);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private static Dictionary<string, string> ConvertFormCollectionIntoDictionary(FormCollection collection)
        {
            var dict = (from key in collection.AllKeys
                select new
                {
                    Key = key,
                    Value = collection[key]
                }).ToDictionary(prop1 => prop1.Key, prop2 => prop2.Value);
            return dict;
        }

        // GET: Checkout/Edit/5
        public ActionResult EditAnItem(Guid id)
        {
            var item = _service.GetItem(id);
            var itemViewModel = new ItemViewModel(item);
            return View(itemViewModel);
        }

        // POST: Checkout/Edit/5
        [HttpPost]
        public ActionResult EditAnItem(Guid id, FormCollection collection)
        {
            try
            {
                var props = typeof (Item).GetProperties();
                var itemToUpdate = _service.GetItem(id);

                var keysThatMatch =
                    from key in collection.AllKeys
                    join prop in props on key equals prop.Name
                    where !prop.Name.Contains("Id")
                    select key;

                foreach (var key in keysThatMatch)
                {
                    typeof (Item).GetProperty(key).SetValue(itemToUpdate, collection[key]);
                }

                _service.ItemRepository.Update(itemToUpdate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Checkout/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Checkout/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}