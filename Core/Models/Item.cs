using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegister.Core.Models
{
    [Table("Item")]
    public class Item
    {
        [Key]
        public Guid ItemId { get; set; } = Guid.NewGuid();
        public string ItemCompanyName { get; set; }
        public string ItemBrandName { get; set; }
        public string ItemDescription { get; set; }
    }
}