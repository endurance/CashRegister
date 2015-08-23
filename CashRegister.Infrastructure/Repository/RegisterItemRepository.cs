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
using Dapper.FastCrud.Mappings;

namespace CashRegister.Infrastructure.Repository
{
    public class RegisterItemRepository : IRepository<Item>
    {
        private string _connectString = "Data Source=CashRegister.sqlite;Version=3;";

        private string _sqlServerConnectString =
            @"Data Source=(localdb)\ProjectsV12;Initial Catalog=CashRegisterSqlExpress;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public RegisterItemRepository()
        {
            CreateRelationships();
            ConnectionString = _sqlServerConnectString;
        }
        public RegisterItemRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private void CreateRelationships()
        {
            OrmConfiguration.RegisterEntity<Item>()
                .SetTableName(nameof(Item))
                .SetProperty(nameof(Item.Id), PropertyMappingOptions.KeyProperty);
            OrmConfiguration.RegisterEntity<ItemVariation>()
                .SetTableName(nameof(ItemVariation))
                .SetProperty(nameof(ItemVariation.Id), PropertyMappingOptions.KeyProperty);
        }


        private DbConnection ConnectionInitialize()
        {
            DbConnection connection = new SqlConnection(ConnectionString);
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
            string query = $"Select * from Item WHERE id = @Id; "
                + $"SELECT * from ItemVariation WHERE = @Id";

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