using CashRegister.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.Infrastructure.Repository;
using CashRegisterDesktopApp.Model;

namespace CashRegisterDesktopApp.ViewModel
{
    internal class CheckoutRegisterViewModel
    {
        public List<RegisterItem> RegisterItems { get; set; }
        public SquareItemRepository ItemRepository { get; set; }
        public CheckoutRegisterViewModel()
        {
            RegisterItems = new List<RegisterItem>();
            ItemRepository = new SquareItemRepository();
        }

        public void AddToRegister(Item item, Guid variationId, int quantity)
        {
            // int systemQuantity = ItemRepository.GetItemVariationQuantity(item_id, variationId);
        }

        public void AddToRegister(Guid itemId, Guid variationId, int quantity)
        {
            RegisterItem item = ItemRepository.FindItem(itemId) as RegisterItem;
            var variation = item.Variations.Find(i => i.Id.Equals(variationId));

            if (variation.Ordinal < quantity) return;
            CalculatePrice(itemId, variationId);
            RegisterItems.Add(item);
        }

        public decimal CalculatePrice(Guid itemId, Guid variationId)
        {
            return 0m;
        }
        
    }
}
