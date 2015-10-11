using System;
using CashRegister.Core.Models;

namespace CashRegister.Core.Repository
{
    public interface IItemRepository : IRepository<Item, Guid>
    { }
}