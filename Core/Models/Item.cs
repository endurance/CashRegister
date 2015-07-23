using System;
using System.Collections.Generic;
using CashRegister.Core.Models.Enums;
using CashRegister.Core.Models.Interfaces;
using Newtonsoft.Json;

namespace CashRegister.Core.Models
{
    public class Item : IItem
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public ItemType Type { get; set; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("available_online")]
        public bool Available_Online { get; set; }

        [JsonProperty("master_image")]
        public ItemImage Master_Image { get; set; }

        [JsonProperty("category")]
        public ItemCategory Category { get; set; }

        [JsonProperty("variations")]
        public List<ItemVariation> Variations { get; set; }

        [JsonProperty("fees")]
        public List<Fee> Fees { get; set; }

        [JsonProperty("modifier_lists")]
        public List<ModifierList> ModifierList { get; set; }

        [JsonProperty("visibility")]
        public ItemVisibility ItemVisibility { get; set; }

        [JsonProperty("color")]
        public ItemColor Color { get; set; }
    }
}