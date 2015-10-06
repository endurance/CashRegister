using System;
using System.ComponentModel;
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
        [DisplayName("Company Name")]
        public string CompanyName => ItemData.ItemCompanyName.Trim();
        [DisplayName("Brand Name")]
        public string ItemBrandName => ItemData.ItemBrandName.Trim();
        [DisplayName("Description")]
        public string Description => ItemData.ItemDescription.Trim();
        [DisplayName("Variation Quantity")]
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
        [DisplayName("Brand Name")]
        public string ItemBrandName => ItemData.ItemBrandName;
        [DisplayName("Variation Sku")]
        public string VariationSku => Variation.VariationSku;
        [DisplayName("Variation Name")]
        public string VariationName => Variation.VariationName;
        [DisplayName("Quantity")]
        public int VariationOrdinal => Variation.VariationOrdinal;
        [DisplayName("Price")]
        public decimal VariationPrice => Variation.VariationPrice;
    }
}