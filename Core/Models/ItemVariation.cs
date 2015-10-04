using System;

namespace CashRegister.Core.Models
{
    public class ItemVariation
    {
        public Guid VariationId { get; set; } = Guid.NewGuid();
        public Guid ItemId { get; set; }
        public string VariationName { get; set; }
        public int VariationOrdinal { get; set; }
        public decimal VariationPrice { get; set; }
        public string VariationSku { get; set; }
    }
}