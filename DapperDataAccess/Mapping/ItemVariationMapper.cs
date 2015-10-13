using CashRegister.Core.Models;

namespace DapperDataAccess
{
    public static class ItemVariationMapper
    {
        public static ItemVariation Map(dynamic value)
        {
            var variation = new ItemVariation()
            {
                Id = value.VariationId,
                ItemId = value.ItemId,
                Price = value.VariationPrice,
                Quantity = value.VariationOrdinal,
                Sku = value.VariationSku,
                VariationName = value.VariationName
            };
            return variation;
        }

    }
}