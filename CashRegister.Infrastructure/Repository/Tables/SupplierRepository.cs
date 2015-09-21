using System.Collections.Generic;
using System.Linq;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.Repository.Abstract;
using Dapper;

namespace CashRegister.Infrastructure.Repository.Tables
{
    public class SupplierRepository : DapperCrudRepository<Supplier>
    {
        public List<Supplier> GetSupplierByName(string name)
        {
            string sql = $"SELECT * from Supplier where name LIKE @name";
            using (var connection = ConnectionIntialize())
            {
                return connection.Query<Supplier>(sql, new {name}).ToList();
            }
        }
    }
}