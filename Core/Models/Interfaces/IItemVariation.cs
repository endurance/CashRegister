using System;

namespace CashRegister.Core.Models.Interfaces
{
    public interface IItemVariation
    {
        Guid VariationId { get; set; }
        Guid ItemId { get; set; }
        string Name { get; set; }
        int Ordinal { get; set; }
        decimal Price { get; set; }
        string Sku { get; set; }
    }
}