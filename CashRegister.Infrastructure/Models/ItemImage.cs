using System;
using Newtonsoft.Json;

namespace CashRegister.Core.Models
{
    public class ItemImage
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("url")]
        public Uri Uri { get; set; }
    }
}