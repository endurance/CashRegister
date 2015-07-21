using System;
using CashRegister.Core.Models.Enums;

namespace CashRegister.Core.Models
{
    public class ItemVariation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Item_Id { get; set; }
        public int Ordinal { get; set; }
        public PricingType Pricing_Type { get; set; }
        public Money ItemPrice { get; set; }
        public string Sku { get; set; }
        public bool Track_Inventory { get; set; }
        public InventoryAlertType Inventory_Alert_Type { get; set; }
        public int Inventory_Alert_Threshold { get; set; }
        public string User_Data { get; set; }
    }
}