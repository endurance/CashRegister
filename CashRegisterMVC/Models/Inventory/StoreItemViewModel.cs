using CashRegister.Core.Models;

namespace CashRegisterMVC.Models.Inventory
{
    public class StoreItemViewModel
    {
        public StoreItem StoreItem { get; set; }
        public string CompanyName => StoreItem.CompanyName.Trim();
        public string ItemBrandName => StoreItem.ItemBrandName.Trim();
        public string Description => StoreItem.Description.Trim();
        public string VariationName => StoreItem.VariationName.Trim();
        public int InventoryAmount => StoreItem.InventoryAmount;
        public decimal Price => StoreItem.Price;
        public string Sku => StoreItem.Sku;
    }
}