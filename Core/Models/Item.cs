using System;
using System.Collections.Generic;
using CashRegister.Core.Models.Enums;
using CashRegister.Core.Models.Interfaces;

namespace CashRegister.Core.Models
{
    public class Item : IItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public string Abbreviation { get; set; }
        public bool Available_Online { get; set; }
        public ItemImage Master_Image { get; set; }
        public ItemCategory Category { get; set; }
        public IEnumerable<ItemVariation> Variations { get; set; }
        public IEnumerable<ModifierList> ModifierList { get; set; }
        public IEnumerable<Fee> Fees { get; set; }
        public ItemVisibility ItemVisibility { get; set; }
        public ItemColor Color { get; set; }
    }
}