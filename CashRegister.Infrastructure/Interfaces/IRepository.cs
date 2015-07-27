using System;
using System.Collections.Generic;

namespace CashRegister.Infrastructure.Interfaces
{
    public interface IRepository<TItem>
    {
        void AddItem(TItem item);
        void UpdateItem(TItem item);
        void DeleteItem(Guid id);
        TItem FindItem(Guid id);
        TItem FindItemBySku(string sku);
        List<TItem> GetAllItems();
    }
}