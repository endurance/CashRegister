using System;
using System.Collections.Generic;
using System.Linq;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.Interfaces;

namespace CashRegister.Infrastructure.Repository
{
    public class InMemoryRepository : IRepository<Item>
    {
        private readonly List<Item> _inventory;
        private readonly SquareItemRepository _repo = new SquareItemRepository();

        public InMemoryRepository()
        {
            _inventory = _repo.GetAllItems();
        }

        public Item FindItemBySku(string sku)
        {
            return _inventory.FirstOrDefault(item => item.Variations
                .Any(variation => variation.Sku.Equals(sku)));
        }

        /// <summary>
        ///     Add Item should have the smarts to take an item and
        ///     A. figure out if this is a new item or an old item
        ///     B. Add the item to the inventory if it is brand new OR
        ///     C. Add the appropriate variation if it already exists
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            // Does the item already exist in the database / inventory?
            var itemIsInInventory = _inventory.Any(i => i.Id == item.Id);

            if (itemIsInInventory)
                throw new ArgumentException($"Item already exists in the inventory. Item: {item}");

            _inventory.Add(item);
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item FindItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetAllItems()
        {
            return _inventory;
        }

        public void Save()
        {
            _inventory.ForEach(_repo.UpdateItem);
        }

        /// <summary>
        ///     Steps:
        ///     Given the variation data, find the item associated
        ///     if the item in the data does not exist, immediately throw
        /// </summary>
        /// <param name="variationData"></param>
        public void AddItemVariation(ItemVariation variationData)
        {
            var query = _inventory.FindAll(i => i.Id == variationData.Item_Id).ToList();

            if (query.Count == 0) throw new ArgumentException("Item does not exist. Variation could not be added");

            if (query.Count > 1)
                throw new ArgumentException("Somehow, we have multiple Items by the same GUID in the database");

            // Item found. Find the variation
            var item = query.First();
            // SKUs are unique, so each item should have different variations that differ BY SKU
            var query2 = item.Variations.FindAll(i => i.Sku.Equals(variationData.Sku)).ToList();

            switch (query2.Count)
            {
                case 0:
                    // no variation exists in this item. add the variation
                    item.Variations.Add(variationData);
                    break;
                case 1:
                    // variation found - increment the inventory
                    var variation = query2.First();
                    variation.Ordinal++;
                    break;
                default:
                    if (query2.Count > 1)
                        throw new ArgumentException("Somehow, we have multiple SKUs in the database: " + variationData.Sku);
                    break;
            }
        }
    }
}