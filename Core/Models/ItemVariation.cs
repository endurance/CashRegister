using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegister.Core.Models
{
    [Table("ItemVariation")]
    public class ItemVariation
    {
        [Key]
        public Guid VariationId { get; set; } = Guid.NewGuid();
        public Guid ItemId { get; set; }
        public string VariationName { get; set; }
        public int VariationOrdinal { get; set; }
        public decimal VariationPrice { get; set; }
        public string VariationSku { get; set; }
    }
}