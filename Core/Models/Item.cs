using System;
using System.Collections.Generic;

namespace CashRegister.Core.Models
{
    public class Item
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual string CompanyName { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual List<ItemVariation> Variations { get; set; } = new List<ItemVariation>();
    }
}