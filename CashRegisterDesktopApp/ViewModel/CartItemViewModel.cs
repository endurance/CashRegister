using System;
using CashRegister.Core.Models;
using Utilities;

namespace CashRegisterDesktopApp.ViewModel
{
    public class CartItemViewModel : BaseViewModel
    {
        private int _quantity = 0;
        
        public CartItemViewModel(Item item, string sku)
        {
            Item = item;
            Sku = sku;
        }

        private Item Item { get; }
        public string Sku { get; set; }
        
        public ItemVariation SelectedUniqueItem
        {
            get { return Item.Variations.Find(i => i.Sku.Equals(Sku)); }
        }

        public string Name => Item.Name + " " + SelectedUniqueItem.Name;

        public string Price => SelectedUniqueItem.Price_Money.Amount.AsCurrency();

        public string CalculatedPrice => (SelectedUniqueItem.Price_Money.Amount*Quantity).AsCurrency();

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value; 
                OnPropertyChanged();
                OnPropertyChanged("CalculatedPrice");
            }
        }
    }
}