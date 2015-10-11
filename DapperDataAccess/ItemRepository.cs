using System;
using CashRegister.Core.Models;
using CashRegister.Core.Repository;

namespace DapperDataAccess
{
    public class ItemRepository : BaseRepository<Item, Guid>, IItemRepository
    {
    }
}