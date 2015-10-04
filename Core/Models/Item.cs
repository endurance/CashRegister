using System;

namespace CashRegister.Core.Models
{
    public class Item
    {
        public Guid ItemId { get; set; } = Guid.NewGuid();
        public string ItemCompanyName { get; set; }
        public string ItemBrandName { get; set; }
        public string ItemDescription { get; set; }
    }
}