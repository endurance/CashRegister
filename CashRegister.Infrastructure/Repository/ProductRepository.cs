using System;
using CashRegister.Core.Models;

namespace CashRegister.Infrastructure.Repository
{
    public class ProductRepository : ISquareInventoryRepository<Product>
    {
        public void SaveItem(Product item)
        {
        }

        public Product GetItem(Guid id)
        {
            return new Product();
        }
    }

    public interface ISquareInventoryRepository<TProduct>
    {
        void SaveItem(TProduct item);
        TProduct GetItem(Guid id);
    }
}