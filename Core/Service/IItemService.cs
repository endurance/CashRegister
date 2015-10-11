using System;
using CashRegister.Core.Models;

namespace CashRegister.Core.Service
{
    public interface IItemService : IService<Item, Guid>
    { }
}