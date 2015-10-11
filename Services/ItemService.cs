using System;
using CashRegister.Core.Models;
using CashRegister.Core.Service;
using DapperDataAccess;

namespace Services
{
    public class ItemService : BaseService<ItemRepository, Item, Guid>, IItemService 
    { }
}