using System;
using CashRegister.Core.Models;
using CashRegister.Core.Repository;

namespace DapperDataAccess
{
    public class SupplierRepository : BaseRepository<Supplier, Guid>, ISupplierRepository
    {
    }
}