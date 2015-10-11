using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegister.Core.Models
{
    [Table("ItemVariation")]
    public class ItemVariation : IDataModel<Guid>
    {
        [Column("ItemId")]
        public Guid ItemId { get; set; }

        [Column("VariationName")]
        public string VariationName { get; set; }

        [Column("VariationOrdinal")]
        public int Quantity { get; set; }

        [Column("VariationPrice")]
        public decimal Price { get; set; }

        [Column("Sku")]
        public string Sku { get; set; }

        [Column("VariationId"), Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}