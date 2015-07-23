using System;
using CashRegister.Infrastructure.Repository;
using NUnit.Framework;

namespace InfrastructureUnitTests
{
    [TestFixture]
    public class RequestsToSquareTester
    {
        [Test]
        public void GetAllItemsTest()
        {
            SquareItemRepository repo = new SquareItemRepository();
            var item = repo.GetAllItems();
            Assert.That(item.Count > 0);
        }
        [Test]
        public void FindOneItem()
        {
            SquareItemRepository repo = new SquareItemRepository();
            Guid itemid = Guid.Parse("af881f06-c3dd-4c74-94d6-58358fb1a8ea");

            var item = repo.FindItem(itemid);

            Assert.That(item.Id == itemid);
        }
    }
}