using System;

namespace CashRegister.Core.Models
{
    public class Supplier
    {
        public Guid SupplierId { get; set; } = Guid.NewGuid();
        public string SupplierName { get; set; }
        public string SupplierDescription { get; set; }
        public string SupplierAddress1 { get; set; }
        public string SupplierAddress2 { get; set; }
        public string SupplierMainPhoneNumber { get; set; }
        public string SupplierAlternatePhoneNumber { get; set; }
    }
}