using System.ComponentModel;
using System.Runtime.Serialization;
using CashRegister.Core.Models;

namespace CashRegisterMVC.Models.Inventory
{
    public class ItemVariationResponse
    {
        [IgnoreDataMember]
        public ItemVariation Variation { get; set; }
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