using System;
using CashRegister.Core.Models.Enums;
using Newtonsoft.Json;

namespace CashRegister.Core.Models
{
    public class Fee
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("rate")]// String representation of a rate - "0.07" would = 7%
        public string Rate { get; set; }
        [JsonProperty("calculation_phase")]
        public CalculationPhaseType CalculationPhase { get; set; }
        [JsonProperty("adjustment_type")]
        public AdjustmentType AdjustmentType { get; set; }
        [JsonProperty("applies_to_custom_amounts")]
        public bool AppliesToCustomAmounts { get; set; }
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
        [JsonProperty("inclusion_type")]
        public InclusionType InclusionType { get; set; }
        [JsonProperty("type")]
        public FeeType FeeType { get; set; }
    }
}