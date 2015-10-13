using System;
using System.Collections.Generic;
using CashRegister.Core.Models;

namespace CashRegister.Core.Service
{
    public interface IItemService : IService<Item, Guid>
    {
        IDictionary<Item, int> GetAllWithInventoryCounts();

    }
}