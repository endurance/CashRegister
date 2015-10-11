using System;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.Models;
using Utilities;

namespace CashRegisterDesktopApp.ViewModel
{
    public class CartItemViewModel : BaseViewModel
    {
        private int _quantity = 0;
        
        public CartItemViewModel(SquareItem item, string sku)
        {
            Item = item;
            Sku = sku;
        }

        private SquareItem Item { get; }
        public string Sku { get; set; }
        
        public ItemVariation SelectedUniqueItem
        {
            get { return Item.Variations.Find(i => i.Sku.Equals(Sku)); }
        }

        public string Name => Item.Name + " " + SelectedUniqueItem.VariationName;

        public decimal Price => SelectedUniqueItem.Price;

        public decimal CalculatedPrice => (SelectedUniqueItem.Price*Quantity);

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