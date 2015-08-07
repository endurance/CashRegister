using CashRegister.Core.Models;

namespace CashRegisterDesktopApp.ViewModel
{
    public class InventoryItemViewModel : BaseViewModel
    {
        public InventoryItemViewModel(Item item, ItemVariation variation)
        {
            Item = item;
            Variation = variation;
        }

        public Item Item { get; set; }
        public ItemVariation Variation { get; set; }

        public string ItemName
        {
            get { return Item.Name; }
            set
            {
                Item.Name = value;
                OnPropertyChanged();
            }
        }

        public string ItemVariationName
        {
            get { return Variation.Name; }
            set
            {
                Variation.Name = value;
                OnPropertyChanged();
            }
        }

        public int Inventory
        {
            get { return Variation.Ordinal; }
            set
            {
                Variation.Ordinal = value;
                OnPropertyChanged();
            }
        }

        public decimal BasePrice
        {
            get { return Variation.Price_Money.Price; }
            set
            {
                Variation.Price_Money.Price = value;
                OnPropertyChanged();
            }
        }

        public string SKU
        {
            get { return Variation.Sku; }
            set
            {
                Variation.Sku = value;
                OnPropertyChanged();
            }
        }
    }
}