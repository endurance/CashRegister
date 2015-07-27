using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.Interfaces;

namespace CashRegister.Infrastructure.Repository
{
    public class InMemoryRepository : IRepository<Item>
    {
        private readonly List<Item> _inventory;
        SquareItemRepository repo = new SquareItemRepository();
        public InMemoryRepository()
        {
            _inventory = repo.GetAllItems();
        }
        public Item FindItemBySku(string sku)
        {
            return _inventory.FirstOrDefault(item => item.Variations
                                        .Any(variation => variation.Sku.Equals(sku)));
        }

        public void Save()
        {
            
        }

        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item FindItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetAllItems()
        {
            throw new NotImplementedException();
        }
    }
}
