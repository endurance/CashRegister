using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.Repository;
using NUnit.Framework;
using Should;

namespace InfrastructureUnitTests
{
    [TestFixture]
    public class LinqToSqlRepoistoryTester
    {
        public string connectionString =
            @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=CashRegisterInventory;Integrated Security=True;Pooling=False";
        [Test]
        public void Add_Item_To_Db()
        {
            LinqToSqlItemRepository repo = new LinqToSqlItemRepository() { ConnectionString = connectionString };
            Item item = new Item()
            {
                CompanyName = "TestCompany",
                Description = "Nothing",
                Name = "TestProduct"
            };
            ItemVariation variation = new ItemVariation()
            {
                ItemId = item.Id,
                Ordinal = 1,
                Price = 5.99M,
                Name = "TestVariation",
                Sku = "12345"
            };
            item.Variations.Add(variation);


            repo.AddItem(item);

        }

        [Test]
        public void Update_Item_From_db()
        {
            LinqToSqlItemRepository repo = new LinqToSqlItemRepository() { ConnectionString = connectionString };
            Guid id = new Guid("af881f06-c3dd-4c74-94d6-58358fb1a8ea");
            var item = repo.GetItem(id);
            item.Name = "AnUpdatedItem";
            repo.UpdateItem(item);
        }

        [Test]
        public void Get_ItemVariation_From_Db()
        {
            LinqToSqlItemRepository repo = new LinqToSqlItemRepository() { ConnectionString = connectionString };
            Guid id = new Guid("760bce54-d2fe-43d9-a802-8a73bed87aa1");
            var itemWithOneVariation = repo.GetVariation(id);

            itemWithOneVariation.Variations.Count.ShouldEqual(1);
        }
    }
}
