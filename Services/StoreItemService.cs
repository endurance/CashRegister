using System;
using System.Collections.Generic;
using System.Linq;
using CashRegister.Core.Models;
using DataAccess;

namespace Services
{
    public class StoreItemService
    {
        public StoreItemService(string connectionString)
        {
            ItemRepository = new ItemRepository {ConnectionString = connectionString};
            ItemVariationRepository = new ItemVariationRepository {ConnectionString = connectionString};
            StoreItemRepository = new StoreItemRepository {ConnectionString = connectionString};
        }

        public ItemRepository ItemRepository { get; set; }
        public ItemVariationRepository ItemVariationRepository { get; set; }
        public StoreItemRepository StoreItemRepository { get; set; }
        
        public Dictionary<Guid, int> GetInventoryPerItem()
        {
            var allVariations = ItemVariationRepository.GetAll();
            var query = (from v in allVariations
                group v by v.ItemId
                into g
                let totalInventory = g.ToList().Sum(i => i.Quantity)
                select new
                {
                    g.Key,
                    totalInventory
                }).ToDictionary(prop1 => prop1.Key, prop2 => prop2.totalInventory);

            return query;
        }

        public void InsertItem(Dictionary<string, string> collection)
        {
            var itemToInsert = ItemMapping(collection);
            ItemRepository.Insert(itemToInsert);
        }

        public void UpdateItem(Dictionary<string, string> collection)
        {
            var itemToUpdate = ItemMapping(collection);
            ItemRepository.Update(itemToUpdate);
        }

        public void InsertItemVariation(Dictionary<string, string> collection)
        {
            var itemVariationToUpdate = ItemVariationMapping(collection);
            ItemVariationRepository.Insert(itemVariationToUpdate);
        }

        public void UpdateItemVariation(Dictionary<string, string> collection)
        {
            var itemVariationToUpdate = ItemVariationMapping(collection);
            ItemVariationRepository.Update(itemVariationToUpdate);
        }
        
        private static Item ItemMapping(Dictionary<string, string> collection)
        {
            var itemToInsert = new Item
            {
                BrandName = collection["ItemBrandName"],
                OriginalCompanyName = collection["ItemCompanyName"],
                Description = collection["ItemDescription"]
            };
            return itemToInsert;
        }
        private static ItemVariation ItemVariationMapping(Dictionary<string, string> collection)
        {
            var itemToInsert = new ItemVariation
            {
                VariationName = collection["VariationName"],
                Quantity = Convert.ToInt32(collection["VariationOrdinal"]),
                Price = Convert.ToDecimal(collection["VariationPrice"]),
                Sku = collection["VariationSku"]
            };
            return itemToInsert;
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