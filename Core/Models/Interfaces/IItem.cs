using System;
using System.Collections.Generic;
using CashRegister.Core.Models.Enums;

namespace CashRegister.Core.Models.Interfaces
{
    public interface IItem
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        ItemType Type { get; set; }
        string Abbreviation { get; set; }
        bool Available_Online { get; set; }
        ItemImage Master_Image { get; set; }
        ItemCategory Category { get; set; }
        List<ItemVariation> Variations { get; set; }
        List<Fee> Fees { get; set; }
        List<ModifierList> ModifierList { get; set; }
        ItemVisibility ItemVisibility { get; set; }
        ItemColor Color { get; set; }
    }
}