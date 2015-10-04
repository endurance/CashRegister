using System;
using System.Collections.Generic;
using CashRegister.Core.Models;
using DataAccess;

namespace Services
{
    public class StoreItemService
    {
        private ItemRepository ItemRepository { get; set; }
        private ItemVariationRepository ItemVariationRepository { get; set; }
        private StoreItemRepository StoreItemRepository { get; set; }

        public StoreItemService(string connectionString)
        {
            ItemRepository = new ItemRepository() { ConnectionString = connectionString };
            ItemVariationRepository = new ItemVariationRepository() { ConnectionString = connectionString };
            StoreItemRepository = new StoreItemRepository() { ConnectionString = connectionString };
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
    }
}