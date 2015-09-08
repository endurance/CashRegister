using System;
using System.Collections.Generic;
using CashRegister.Core.Models.Interfaces;

namespace CashRegister.Core.Models
{
    public class Item<T> : IItem<T> where T : IItemVariation
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual string CompanyName { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual List<T> Variations { get; set; } = new List<T>();
    }

    public class Item : Item<ItemVariation>
    { }
}