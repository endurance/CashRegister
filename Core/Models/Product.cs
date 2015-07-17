using System;

namespace CashRegister.Core.Models
{
    public class Product
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}