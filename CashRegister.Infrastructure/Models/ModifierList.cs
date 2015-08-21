using System;
using System.Collections.Generic;
using CashRegister.Core.Models;
using CashRegister.Core.Models.Enums;
using Newtonsoft.Json;

namespace CashRegister.Infrastructure.Models
{
    public class ModifierList
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("selection_type")]
        public SelectionType SelectionType { get; set; }
        [JsonProperty("modifier_options")]
        public List<ModifierOptions> Modifier_Options { get; set; }
    }
}