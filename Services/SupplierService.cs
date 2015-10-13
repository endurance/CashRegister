using System;
using CashRegister.Core.Models;
using CashRegister.Core.Service;
using DapperDataAccess;

namespace Services
{
    public class SupplierService : BaseService<SupplierRepository, Supplier, Guid>, ISupplierService
    {
        public SupplierService(SupplierRepository repository) : base(repository)
        {
        }
    }
}