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
            get { return Variation.VariationName; }
            set
            {
                Variation.VariationName = value;
                OnPropertyChanged();
            }
        }

        public int Inventory
        {
            get { return Variation.VariationOrdinal; }
            set
            {
                Variation.VariationOrdinal = value;
                OnPropertyChanged();
            }
        }

        public decimal BasePrice
        {
            get { return Variation.VariationPrice; }
            set
            {
                Variation.VariationPrice = value;
                OnPropertyChanged();
            }
        }

        public string SKU
        {
            get { return Variation.VariationSku; }
            set
            {
                Variation.VariationSku = value;
                OnPropertyChanged();
            }
        }
    }
}