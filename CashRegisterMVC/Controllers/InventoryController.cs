﻿using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using CashRegister.Core.Models;
using CashRegisterMVC.Models;
using Services;

namespace CashRegisterMVC.Controllers
{
    public class InventoryController : Controller
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;

        //readonly IRepository _itemRepository = new LinqToSqlItemRepository() { ConnectionString = connectionString };
        private readonly StoreItemService service = new StoreItemService(connectionString);
        // GET: Checkout
        public ActionResult Index()
        {
            var items = service.GetAllItems();
            var itemViewModels = items.Select(i => new ItemViewModel(i)).ToList();
            return View(itemViewModels);
        }

        // GET: Checkout/Details/5
        public ActionResult ItemVariationDetails(Guid id)
        {


            //var itemModel = service.GetItem(id);
            //var itemVariationViewModels =
            //    itemModel.Variations.Select(i => new ItemVariationViewModel(itemModel, i)).ToList();
            //return View(itemVariationViewModels);
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
                var props = typeof (Item).GetProperties();
                var itemToInsert = new Item();

                var keysThatMatch =
                    from key in collection.AllKeys
                    join propName in props on key equals propName.Name
                    select key;

                foreach (var key in keysThatMatch)
                {
                    typeof (Item).GetProperty(key).SetValue(itemToInsert, collection[key]);
                }

                _itemRepository.AddItem(itemToInsert);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Checkout/Edit/5
        public ActionResult EditAnItem(Guid id)
        {
            var item = _itemRepository.GetItem(id);
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
                var itemToUpdate = _itemRepository.GetItem(id);

                var keysThatMatch =
                    from key in collection.AllKeys
                    join prop in props on key equals prop.Name
                    where !prop.Name.Contains("Id")
                    select key;

                foreach (var key in keysThatMatch)
                {
                    typeof (Item).GetProperty(key).SetValue(itemToUpdate, collection[key]);
                }

                _itemRepository.UpdateItem(itemToUpdate);
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