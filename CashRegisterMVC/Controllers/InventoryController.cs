using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.Interfaces;
using CashRegister.Infrastructure.Repository;
using CashRegisterMVC.Models;

namespace CashRegisterMVC.Controllers
{
    public class InventoryController : Controller
    {
        readonly IRepository _itemRepository = new LinqToSqlItemRepository() { ConnectionString = connectionString };
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
        // GET: Checkout
        public ActionResult Index()
        {
            var items = _itemRepository.GetAllItems();
            var query =
                (from it in items
                    select new ItemViewModel(it)).ToList();
            return View(query);
        }

        // GET: Checkout/Details/5
        public ActionResult ItemVariationDetails(Guid id)
        {
            var itemModel = _itemRepository.GetItem(id);
            var query =
                (from itemVariation in itemModel.Variations
                 select new ItemVariationViewModel(itemModel, itemVariation)).ToList();
            return View(query);
        }

        // GET: Checkout/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Checkout/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Checkout/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Checkout/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
