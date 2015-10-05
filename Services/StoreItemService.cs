using System;
using System.Collections.Generic;
using System.Linq;
using CashRegister.Core.Models;
using DataAccess;

namespace Services
{
    public class StoreItemService
    {
        public ItemRepository ItemRepository { get; set; }
        public ItemVariationRepository ItemVariationRepository { get; set; }
        public StoreItemRepository StoreItemRepository { get; set; }

        public StoreItemService(string connectionString)
        {
            ItemRepository = new ItemRepository() { ConnectionString = connectionString };
            ItemVariationRepository = new ItemVariationRepository() { ConnectionString = connectionString };
            StoreItemRepository = new StoreItemRepository() { ConnectionString = connectionString };
        }


        public void InsertItem(Dictionary<string, string> collection)
        {
            var props = typeof(Item).GetProperties();
            var itemToInsert = new Item();

            var keysThatMatch =
                from key in collection.Keys
                join propName in props on key equals propName.Name
                select key;

            foreach (var key in keysThatMatch)
            {
                typeof(Item).GetProperty(key).SetValue(itemToInsert, collection[key]);
            }

            ItemRepository.Insert(itemToInsert);
        }

        public List<Item> GetAllItems()
        {
            return ItemRepository.GetAll();
        } 

        public Item GetItem(Guid itemId)
        {
            return ItemRepository.Get(itemId);
        }

        public ItemVariation GetItemVariation(Guid variationId)
        {
            return ItemVariationRepository.Get(variationId);
        }

        public StoreItem GetStoreItem(Guid variationId)
        {
            return StoreItemRepository.Get(variationId);
        }

        public StoreItem GetStoreItem(string sku)
        {
            return StoreItemRepository.GetBySku(sku);
        }

        public List<StoreItem> GetAllStoreItems()
        {
            return StoreItemRepository.GetAllStoreItems();
        }

        public List<StoreItem> GetAllStoreItemsWithId(Guid itemId)
        {
            return StoreItemRepository.GetAllStoreItemsByItemId(itemId);
        }
    }
}