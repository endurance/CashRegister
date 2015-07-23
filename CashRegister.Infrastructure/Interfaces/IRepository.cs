using System;
using System.Collections.Generic;

namespace CashRegister.Infrastructure.Repository
{
    public interface IRepository<TItem>
    {
        void AddItem(TItem item);
        void UpdateItem(TItem item);
        void DeleteItem(Guid id);
        TItem FindItem(Guid id);
        List<TItem> GetAllItems();
    }
}