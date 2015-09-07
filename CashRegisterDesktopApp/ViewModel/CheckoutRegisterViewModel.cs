using System.Collections.ObjectModel;
using System.Windows.Data;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.Interfaces;
using CashRegister.Infrastructure.Models;
using CashRegister.Infrastructure.Repository;
using Utilities;

namespace CashRegisterDesktopApp.ViewModel
{
    public class CheckoutRegisterViewModel
    {
        private static readonly object syncLock = new object();
        public Scanner Scanner = new Scanner();

        public CheckoutRegisterViewModel()
        {
            CartItems = new ObservableCollection<CartItemViewModel>();
            BindingOperations.EnableCollectionSynchronization(CartItems, syncLock);
            ItemRepository = new InMemoryRepository();
            Scanner.Scanned += OnScan;
        }

        public ObservableCollection<CartItemViewModel> CartItems { get; set; }
        public IItemRepository<SquareItem> ItemRepository { get; set; }
        public string CurrentSku { get; set; }

        public void OnScan()
        {
            // This thing is constantly scanning keyboard input.
            // Don't perform any other tasks if the keys entered were under 6
            if (Scanner.ScannedString.Length < 6) return;
            CurrentSku = Scanner.ScannedString;
            AddToRegister(CurrentSku);
        }

        public void AddToRegister(string sku)
        {
            // Find the Item
            var item = ItemRepository.GetItemBySku(CurrentSku);
            // If no item found, leave
            if (item == null) return;
            // Create Item view model
            var vm = new CartItemViewModel(item, CurrentSku) { Quantity = 1 };
            // Add to the register
            CartItems.Add(vm);
        }
    }
}