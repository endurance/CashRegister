using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.Interfaces;
using Dapper;

namespace CashRegister.Infrastructure.Repository
{
    public class RegisterItemRepository : IRepository<Item>
    {
        private readonly string _sqlServerConnectString =
            @"Data Source=(localdb)\ProjectsV12;Initial Catalog=CashRegisterSqlExpress;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private string _connectString = "Data Source=CashRegister.sqlite;Version=3;";

        public RegisterItemRepository()
        {
            ConnectionString = _sqlServerConnectString;
        }

        public RegisterItemRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }
        public DbConnection Connection { get; set; }

        public void AddItem(Item item)
        {
            using (var connection = ConnectionInitialize())
            {
                //connection.Insert(item);
            }
        }

        public void UpdateItem(Item item)
        {
            using (var connection = ConnectionInitialize())
            {
                //connection.Update(item);
            }
        }

        public void DeleteItem(Guid id)
        {
            string query = $"DELETE FROM Item WHERE ID = {id}";
            using (var connection = ConnectionInitialize())
            {
                connection.Query(query);
            }
        }

        public Item GetItemById(Guid id)
        {
            string findItem = $"Select * from Item WHERE id = @Id;";
            string findVariations = $"SELECT * from ItemVariation WHERE itemid = @Id";
            var query = findItem + findVariations;

            using (var connection = ConnectionInitialize())
            using (var results = connection.QueryMultiple(query, new {id}))
            {
                var item = results.Read<Item>().SingleOrDefault();
                var itemVariations = results.Read<ItemVariation>().ToList();

                item?.Variations?.AddRange(itemVariations);

                return item;
            }
        }

        public Item GetItemBySku(string sku)
        {
            var query = $"Select * from Item it " +
                        $"INNER JOIN ItemVariation iv on iv.itemid = it.ID " +
                        $"WHERE SKU = {sku}";

            using (var connection = ConnectionInitialize())
            {
                return connection.Query<Item, ItemVariation, Item>(query,
                    (item, itemVariation) =>
                    {
                        item.Variations.Add(itemVariation);
                        return item;
                    }).SingleOrDefault();
            }
        }

        public List<Item> GetAllItems()
        {
            string query = $"Select * from Item it" +
                           $"INNER JOIN ItemVariation iv on iv.itemId = it.id";

            using (var connection = ConnectionInitialize())
            {
                return connection.Query<Item, ItemVariation, Item>(query,
                    (item, itemVariation) =>
                    {
                        item.Variations.Add(itemVariation);
                        return item;
                    }).ToList();
            }
        }

        private DbConnection ConnectionInitialize()
        {
            DbConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}