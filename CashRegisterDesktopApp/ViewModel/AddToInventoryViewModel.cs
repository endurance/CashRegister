using System.Collections.ObjectModel;
using CashRegister.Infrastructure.Interfaces;
using CashRegister.Infrastructure.Models;
using CashRegister.Infrastructure.Repository;

namespace CashRegisterDesktopApp.ViewModel
{
    public class AddToInventoryViewModel : BaseViewModel
    {
        private decimal _basePrice;
        private string _currentScannedSku;
        private int _inventory;
        private string _itemName;
        private string _itemVariationName;
        private IItemRepository<SquareItem> _repo;
        private string _sku;

        public AddToInventoryViewModel()
        {
            _repo = new InMemoryRepository();
        }

        public AddToInventoryViewModel(IItemRepository<SquareItem> repo)
        {
            _repo = repo;
        }

        public ObservableCollection<InventoryItemViewModel> InventoryItems { get; set; }

        public string CurrentScannedSku
        {
            get { return _currentScannedSku; }
            set
            {
                if (value == _currentScannedSku) return;
                _currentScannedSku = value;
                OnPropertyChanged();
            }
        }
    }
}