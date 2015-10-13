using System;
using CashRegister.Core.Connection;
using CashRegister.Core.Models;
using CashRegister.Core.Repository;

namespace DapperDataAccess
{
    public class SupplierRepository : BaseRepository<Supplier, Guid>, ISupplierRepository
    {
        public SupplierRepository(IConnectionProvider connectionProvider, IConnectionStringProvider connectionStringProvider) : base(connectionProvider, connectionStringProvider)
        {
        }
    }
}