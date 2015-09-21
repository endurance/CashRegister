using System;
using System.Collections.Generic;

namespace CashRegister.Core.Models
{
    public class ItemVariation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public int Ordinal { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}