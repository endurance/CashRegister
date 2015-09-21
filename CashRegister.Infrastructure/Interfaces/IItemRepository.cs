using System;
using System.Collections.Generic;
using CashRegister.Core.Models;

namespace CashRegister.Infrastructure.Interfaces
{
    public interface IItemRepository<TItem>
    {
        void AddItem(TItem item);
        void UpdateItem(TItem item);
        void DeleteItem(Guid id);
        TItem GetItemById(Guid id);
        TItem GetItemBySku(string sku);
        List<TItem> GetAllItems();
    }
    public interface IRepository
    {
        void AddItem(Item obj);
        void AddItemVariation(ItemVariation itemVariation);
        void UpdateItem(Item item);
        void UpdateItemVariation(ItemVariation itemVariation);
        void DeleteItem(Item item);
        void DeleteItemVariation(Item itemVariation);
        Item GetItem(Guid id);
        Item GetItem(ItemVariation variation);
        Item GetVariation(Guid id);
        Item GetVariation(string sku);
        List<Item> GetAllItems();
        List<ItemVariation> GetAllItemVariations();
    }

}