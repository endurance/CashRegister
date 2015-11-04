using System.ComponentModel;
using System.Runtime.Serialization;
using CashRegister.Core.Models;
namespace CashRegisterMVC.Models.Inventory
{
    public class StoreItemResponse
    {
        [IgnoreDataMember]
        public StoreItem StoreItem { get; set; }
        [DisplayName("Company Name")]
        public string CompanyName => StoreItem.CompanyName.Trim();
        [DisplayName("Description")]
        public string Description => StoreItem.Description.Trim();
        [DisplayName("Variation Name")]
        public string VariationName => StoreItem.VariationName.Trim();
        [DisplayName("Quantity")]
        public int InventoryAmount => StoreItem.Quantity;
        [DisplayName("Price")]
        public decimal Price => StoreItem.Price;
        [DisplayName("Sku")]
        public string Sku => StoreItem.Sku;
        
    }
}