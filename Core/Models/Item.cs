using System;
using System.Collections.Generic;

namespace CashRegister.Core.Models
{
    public class Item : IItem
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType ItemType { get; set; }
        public string Abbreviation { get; set; }
        public bool AvailableOnline { get; set; }
        public ItemImage Master_Image { get; set; }
        public ItemCategory Category { get; set; }
        public IEnumerable<ItemVariation> variations { get; set; }
        public IEnumerable<Fee> Fees { get; set; }
    }
}