using System;
using CashRegister.Core.Models.Enums;
using Newtonsoft.Json;

namespace CashRegister.Core.Models
{
    public class ItemVariation
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("item_id")]
        public Guid Item_Id { get; set; }
        [JsonProperty("ordinal")]
        public int Ordinal { get; set; }
        [JsonProperty("pricing_type")]
        public PricingType Pricing_Type { get; set; }
        [JsonProperty("price_money")]
        public Money Price_Money { get; set; }
        [JsonProperty("sku")]
        public string Sku { get; set; }
        [JsonProperty("track_inventory")]
        public bool Track_Inventory { get; set; }
        [JsonProperty("inventory_alert_type")]
        public InventoryAlertType Inventory_Alert_Type { get; set; }
        [JsonProperty("inventory_alert_threshold")]
        public int Inventory_Alert_Threshold { get; set; }
        [JsonProperty("user_data")]
        public string User_Data { get; set; }
    }
}