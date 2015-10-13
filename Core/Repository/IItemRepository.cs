using System;
using System.Collections;
using CashRegister.Core.Models;
using System.Collections.Generic;

namespace CashRegister.Core.Repository
{
    public interface IItemRepository : IRepository<Item, Guid>
    {
    }
}