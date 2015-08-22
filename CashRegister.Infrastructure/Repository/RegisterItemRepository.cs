using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.Interfaces;
using Dapper;
using Dapper.FastCrud;

namespace CashRegister.Infrastructure.Repository
{
    public class RegisterItemRepository : IRepository<Item>
    {
        private string _connectString = "Data Source=CashRegister.sqlite;Version=3;";

        public RegisterItemRepository()
        {
            ConnectionString = _connectString;
        }
        public RegisterItemRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private DbConnection ConnectionInitialize()
        {
            DbConnection connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public string ConnectionString { get; set; }
        public DbConnection Connection { get; set; }
        public void AddItem(Item item)
        {
            using (var connection = ConnectionInitialize())
            {
                connection.Insert(item);
            }
        }

        public void UpdateItem(Item item)
        {
            using (var connection = ConnectionInitialize())
            {
                connection.Update(item);
            }
        }

        public void DeleteItem(Guid id)
        {
            using (var connection = ConnectionInitialize())
            {
                var item = GetItemById(id);
                connection.Delete(item);
            }
        }

        public Item GetItemById(Guid id)
        {
            using (var connection = ConnectionInitialize())
            {
                return connection.Get(new Item {Id = id});
            }
        }

        public Item GetItemBySku(string sku)
        {
            string query = $"Select * from Item INNER JOIN ItemVariation iv on iv.sku = {sku}";

            using (var connection = ConnectionInitialize())
            {
                return connection.Query<Item>(query).First();
            }
        }

        public List<Item> GetAllItems()
        {
            string query = $"Select * from Item";

            using (var connection = ConnectionInitialize())
            {
                return connection.Query<Item>(query).ToList();
            }
        }
    }
}