using System;
using System.Linq;
using System.Reflection;
using CashRegister.Core.Models;

namespace CashRegister.Infrastructure.DataContexts.Mapping
{
    public static class Mapping
    {
        internal static void MapObject(this object objectToHydrate, object objectWithData)
        {
            var emptyProperties = objectToHydrate.GetType().GetProperties();
            var dataProperties = objectWithData.GetType().GetProperties();

            var matchedProperties =
                (from data in dataProperties
                join empty in emptyProperties on data.Name equals empty.Name
                select Tuple.Create(empty, data)).ToList();

            foreach (var match in matchedProperties)
            {
                var empty = match.Item1;
                var data = match.Item2;

                var value = data.GetValue(objectWithData, null);
                empty.SetValue(objectToHydrate, value, null);
            }
        }

        public static void MapToItemObject(this Item hydrateItem, ItemDb itemWithData)
        {
            hydrateItem.MapObject(itemWithData);
            foreach (var variation in itemWithData.ItemVariationDbs)
            {
                var hydrateVariation = new ItemVariation();
                hydrateVariation.MapToItemVariationObject(variation);
                hydrateItem.Variations.Add(hydrateVariation);
            }
        }

        public static Item MapToItemObject(ItemDb itemWithData)
        {
            Item item = new Item();
            item.MapToItemObject(itemWithData);
            return item;
        }

        public static void MapToItemVariationObject(this ItemVariation itemVariation, ItemVariationDb itemVariationWithItem)
        {
            itemVariation.MapObject(itemVariationWithItem);
        }

        public static void MapToItemDbObject(this ItemDb hydrateItem, Item itemWithData)
        {
            if (hydrateItem.Id != itemWithData.Id) hydrateItem.Id = itemWithData.Id;
            hydrateItem.Name = itemWithData.Name;
            hydrateItem.CompanyName = itemWithData.CompanyName;
            hydrateItem.Description = itemWithData.Description;
        }

        public static void MapToItemVariationDbObject(this ItemVariationDb hydrateItem, ItemVariation itemWithData)
        {
            hydrateItem.Name = itemWithData.Name;
            hydrateItem.Ordinal = itemWithData.Ordinal;
            hydrateItem.Price = itemWithData.Price;
            hydrateItem.Sku = itemWithData.Sku;
        }
    }
}
