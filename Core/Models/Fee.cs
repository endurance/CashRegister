using System;

namespace CashRegister.Core.Models
{
    public class Fee
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        // String representation of a rate - "0.07" would = 7%
        public string Rate { get; set; }
        public CalculationPhaseType CalculationPhase { get; set; }
        public AdjustmentType AdjustmentType { get; set; }
        public bool AppliesToCustomAmounts { get; set; }
        public bool Enabled { get; set; }
        public InclusionType InclusionType { get; set; }
        public FeeType FeeType { get; set; }
    }
}