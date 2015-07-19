using System;
using System.Collections.Generic;

namespace CashRegister.Core.Models
{
    public interface IItem
    {
        Guid Identifier { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        ItemType ItemType { get; set; }
        string Abbreviation { get; set; }
        bool AvailableOnline { get; set; }
        ItemImage Master_Image { get; set; }
        ItemCategory Category { get; set; }
        IEnumerable<ItemVariation> variations { get; set; }
        IEnumerable<Fee> Fees { get; set; }
    }
}