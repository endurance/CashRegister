using System;
using CashRegister.Core.Models;
using CashRegister.Core.Models.Enums;
using Newtonsoft.Json;

namespace CashRegister.Infrastructure.Models
{
    public class SquareItemVariation : ItemVariation
    {
        [JsonProperty("id")]
        public override Guid VariationId { get; set; }
        [JsonProperty("name")]
        public override string Name { get; set; }
        [JsonProperty("item_id")]
        public override Guid ItemId { get; set; }
        [JsonProperty("ordinal")]
        public override int Ordinal { get; set; }

        public override decimal Price
        {
            get { return Price_Money.Amount/100; }
            set { Price_Money.Amount = (int)value*100; }
        }

        [JsonProperty("pricing_type")]
        public PricingType Pricing_Type { get; set; }
        [JsonProperty("price_money")]
        public Money Price_Money { get; set; }
        [JsonProperty("sku")]
        public override string Sku { get; set; }
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