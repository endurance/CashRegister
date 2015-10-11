using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using CashRegister.Core.Models;
using Dapper;

namespace DataAccess
{
    public class StoreItemRepository : IRepository
    {
        public string ConnectionString { get; set; }

        public virtual DbConnection GetDbConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
        public StoreItem Get(Guid variationId)
        {
            var sql = "SELECT * from Item " +
                      "INNER JOIN ItemVariation on Item.ItemId = ItemVariation.ItemId " +
                      "WHERE ItemVariation.VariationId = @variationId;";
            using (var connection = GetDbConnection(ConnectionString))
            {
                var result = connection.Query(sql, new { variationId }).FirstOrDefault();

                return result == null ? null : StoreItemMapper(result);
            }
        }

        public StoreItem GetBySku(string sku)
        {
            var sql = "SELECT * from Item " +
                      "INNER JOIN ItemVariation on Item.ItemId = ItemVariation.ItemId " +
                      "WHERE ItemVariation.VariationSku = @sku;";
            using (var connection = GetDbConnection(ConnectionString))
            {
                var result = connection.Query(sql, new {  sku }).FirstOrDefault();

                return result == null ? null : StoreItemMapper(result);
            }
        }

        public List<StoreItem> GetAllStoreItems()
        {
            var sql = "SELECT * from Item " +
                      "INNER JOIN ItemVariation on Item.ItemId = ItemVariation.ItemId";
            using (var connection = GetDbConnection(ConnectionString))
            {
                var result = connection.Query(sql, null);
                if (result == null) return null;
                var query = (from obj in result
                    select (StoreItem)StoreItemMapper(obj)).ToList();
                return query;
            }
        }

        public List<StoreItem> GetAllStoreItemsByItemId(Guid id)
        {
            var sql = "SELECT * from Item " +
                      "INNER JOIN ItemVariation on Item.ItemId = ItemVariation.ItemId " +
                      "where Item.ItemId = @id";
            using (var connection = GetDbConnection(ConnectionString))
            {
                var result = connection.Query(sql, new { id = id});
                if (result == null) return null;
                var query = (from obj in result
                             select (StoreItem)StoreItemMapper(obj)).ToList();
                return query;
            }

        } 

        public void Insert(StoreItem item)
        {
            var sql = @"INSERT INTO Item (ItemId, ItemBrandName, ItemDescription, ItemCompanyName) " +
                      " VALUES (@ItemId, @ItemBrandName, @ItemDescription, @ItemCompanyName);" +
                      "INSERT INTO ItemVariation (VariationId, ItemId, VariationSku, VariationName, VariationOrdinal, VariationPrice) " +
                      " VALUES (@VariationId, @ItemId, @VariationSku, @VariationName, @VariationOrdinal, @VariationPrice)";
            using (var connection = GetDbConnection(ConnectionString))
            {
                connection.QueryMultiple(sql,
                    new
                    {
                        item.ItemId,
                        item.ItemBrandName,
                        ItemCompanyName = item.CompanyName,
                        ItemDescription = item.Description,
                        item.VariationId,
                        VariationSku = item.Sku,
                        item.VariationName,
                        VariationOrdinal = item.Quantity,
                        VariationPrice = item.Price
                    });
            }
        }

        public void Update(StoreItem item)
        {
            string sql = @"UPDATE Item " +
                         "Set ItemBrandName = @ItemBrandName, " +
                         "ItemDescription = @ItemDescription, " +
                         "ItemCompanyName = @ItemCompanyName " +
                         "WHERE item.Id = @ItemId;" +
                         "UPDATE ItemVariation " +
                         "SET VariationSku = @VariationSku, " +
                         "VariationName = @VariationName, " +
                         "VariationOrdinal = @VariationOrdinal, " +
                         "VariationPrice = @VariationPrice " +
                         "WHERE ItemVariation.VariationId = @VariationId;";
            using (var connection = GetDbConnection(ConnectionString))
            {
                connection.QueryMultiple(sql,
                    new
                    {
                        item.ItemId,
                        item.ItemBrandName,
                        ItemCompanyName = item.CompanyName,
                        ItemDescription = item.Description,
                        item.VariationId,
                        VariationSku = item.Sku,
                        item.VariationName,
                        VariationOrdinal = item.Quantity,
                        VariationPrice = item.Price
                    });
            }
        }

        private static StoreItem StoreItemMapper(dynamic result)
        {
            var item = new StoreItem
            {
                // Item mapping
                ItemId = result.ItemId,
                VariationId = result.VariationId,
                ItemBrandName = result.ItemName,
                Description = result.ItemDescription,
                CompanyName = result.ItemCompanyName,
                // ItemVariation Mapping
                Sku = result.VariationSku,
                VariationName = result.VariationName,
                Quantity = result.VariationOrdinal,
                Price = result.VariationPrice
            };
            return item;
        }
    }
}