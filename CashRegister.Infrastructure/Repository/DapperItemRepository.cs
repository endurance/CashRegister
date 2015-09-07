using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.Interfaces;

namespace CashRegister.Infrastructure.Repository
{
    public class DapperItemRepository : IRepository
    {
        public string ConnectionString { get; set; }

        public void AddItem(Item obj)
        {
            throw new NotImplementedException();
        }

        public void AddItemVariation(ItemVariation itemVariation)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void UpdateItemVariation(ItemVariation itemVariation)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItemVariation(Item itemVariation)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(ItemVariation variation)
        {
            throw new NotImplementedException();
        }

        public Item GetVariation(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetVariation(string sku)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public List<ItemVariation> GetAllItemVariations()
        {
            throw new NotImplementedException();
        }
    }
}
