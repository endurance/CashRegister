using System;
using CashRegister.Core.Models.Interfaces;

namespace CashRegister.Core.Models
{
    public class ItemVariation : IItemVariation
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual Guid ItemId { get; set; }
        public virtual string Name { get; set; }
        public virtual int Ordinal { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Sku { get; set; }
    }
}