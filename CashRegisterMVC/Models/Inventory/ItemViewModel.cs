using System;
using System.Linq;
using CashRegister.Core.Models;

namespace CashRegisterMVC.Models
{
    public class ItemViewModel
    {
        public ItemViewModel(Item itemData)
        {
            ItemData = itemData;
        }

        public Item ItemData { get; set; }
        public Guid Id => ItemData.Id;
        public string Name => ItemData.Name;
        public string Description => ItemData.Description;
        public int TotalQuantity
        {
            get { return ItemData.Variations.Sum(i => i.Ordinal); }
        }
    }

    public class ItemVariationViewModel
    {
        public ItemVariation Variation { get; set; }
        public Item ItemData { get; set; }
        public ItemVariationViewModel(Item itemData, ItemVariation itemVariationData)
        {
            ItemData = itemData;
            Variation = itemVariationData;
        }

        public string CoreItemName => ItemData.Name;
        public string Sku => Variation.Sku;
        public string TypeName => Variation.Name;
        public int Quantity => Variation.Ordinal;
        public decimal Price => Variation.Price;
    }
}