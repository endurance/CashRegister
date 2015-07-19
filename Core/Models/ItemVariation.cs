using System;

namespace CashRegister.Core.Models
{
    public class ItemVariation
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public Guid Item_Identifier { get; set; }
        public int ordinal { get; set; }
        public PricingType PricingType { get; set; }
        public Money ItemPrice { get; set; }
        public string SKU { get; set; }
        public bool TrackInventory { get; set; }
        public InventoryAlertType AlertType { get; set; }
        public int AlertThreshold { get; set; }
        public string UserData { get; set; }
    }
}