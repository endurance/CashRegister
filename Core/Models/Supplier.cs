using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegister.Core.Models
{
    [Table("Supplier")]
    public class Supplier : IDataModel<Guid>
    {
        [Column("SupplierName")]
        public string Name { get; set; }

        [Column("SupplierDescription")]
        public string Description { get; set; }

        [Column("SupplierAddress1")]
        public string Address1 { get; set; }

        [Column("SupplierAddress2")]
        public string Address2 { get; set; }

        [Column("SupplierMainPhoneNumber")]
        public string MainPhoneNumber { get; set; }

        [Column("SupplierAlternatePhoneNumber")]
        public string AlternatePhoneNumber { get; set; }

        [Column("SupplierId")]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}