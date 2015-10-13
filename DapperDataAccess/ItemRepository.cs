using System;
using System.Collections.Generic;
using CashRegister.Core.Connection;
using CashRegister.Core.Models;
using CashRegister.Core.Repository;

namespace DapperDataAccess
{
    public class ItemRepository : BaseRepository<Item, Guid>, IItemRepository
    {
        public ItemRepository(IConnectionProvider connectionProvider, IConnectionStringProvider connectionStringProvider) : base(connectionProvider, connectionStringProvider)
        {
        }
    }
}