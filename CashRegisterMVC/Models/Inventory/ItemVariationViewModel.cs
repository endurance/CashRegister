using System.ComponentModel;
using CashRegister.Core.Models;

namespace CashRegisterMVC.Models.Inventory
{
    public class ItemVariationViewModel
    {
        public ItemVariation Variation { get; set; }
        public ItemVariationViewModel(ItemVariation itemVariationData)
        {
            Variation = itemVariationData;
        }
        [DisplayName("Variation Sku")]
        public string VariationSku => Variation.Sku;
        [DisplayName("Variation Name")]
        public string VariationName => Variation.VariationName;
        [DisplayName("Quantity")]
        public int VariationOrdinal => Variation.Quantity;
        [DisplayName("Price")]
        public decimal VariationPrice => Variation.Price;
    }
}