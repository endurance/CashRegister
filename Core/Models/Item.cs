using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegister.Core.Models
{
    [Table("Item")]
    public class Item : IDataModel<Guid>
    {
        [Column("ItemCompanyName")]
        public string OriginalCompanyName { get; set; }

        [Column("ItemBrandName")]
        public string BrandName { get; set; }

        [Column("ItemDescription")]
        public string Description { get; set; }

        [Column("ItemId"), Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}