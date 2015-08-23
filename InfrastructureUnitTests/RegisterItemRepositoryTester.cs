using System;
using CashRegister.Infrastructure.Repository;
using NUnit.Framework;

namespace InfrastructureUnitTests
{
    [TestFixture]
    public class RegisterItemRepositoryTester
    {
        [Test]
        public void GetAllItemsTest()
        {
            RegisterItemRepository repo = new RegisterItemRepository();
            var item = repo.GetAllItems();
            Assert.That(item.Count > 0);
        }
        [Test]
        public void FindOneItem()
        {
            RegisterItemRepository repo = new RegisterItemRepository();
            Guid itemid = Guid.Parse("af881f06-c3dd-4c74-94d6-58358fb1a8ea");

            var item = repo.GetItemById(itemid);

            Assert.That(item.Id == itemid);
        }
    }
}