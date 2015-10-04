using System;
using System.Linq;
using CashRegister.Core.Models;
using Dapper;

namespace DataAccess
{
    public class ItemRepository : BaseRepository<Item>
    { }

    public class ItemVariationRepository : BaseRepository<ItemVariation>
    {
        public ItemVariation GetBySku(string sku)
        {
            string sql = "SELECT * from ItemVariation where ItemVariation.VariationSku = @Sku";
            using (var connection = GetDbConnection(ConnectionString))
            {
                return connection.Query<ItemVariation>(sql, new { Sku = sku }).FirstOrDefault();
            }
        }

    }
    public class SupplierRepository : BaseRepository<Supplier>
    { }
}