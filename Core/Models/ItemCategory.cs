using System;
using Newtonsoft.Json;

namespace CashRegister.Core.Models
{
    public class ItemCategory
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}