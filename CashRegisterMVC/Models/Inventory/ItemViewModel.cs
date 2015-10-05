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
        public Guid Id => ItemData.ItemId;
        public string CompanyName => ItemData.ItemCompanyName.Trim();
        public string Name => ItemData.ItemCompanyName.Trim();
        public string Description => ItemData.ItemDescription.Trim();
        public int TotalInventory { get; set; }
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

        public string CoreItemName => ItemData.ItemBrandName;
        public string Sku => Variation.VariationSku;
        public string TypeName => Variation.VariationName;
        public int Quantity => Variation.VariationOrdinal;
        public decimal Price => Variation.VariationPrice;
    }
}