using System;

namespace CashRegister.Core.Models
{
    public class StoreItem
    {
        public Guid ItemId { get; set; }
        public Guid VariationId { get; set; }
        public string CompanyName { get; set; }
        public string ItemBrandName { get; set; }
        public string Description { get; set; }
        public string VariationName { get; set; }
        public int InventoryAmount { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
    }
}