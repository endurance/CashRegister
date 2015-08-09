using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.Interfaces;
using CashRegister.Infrastructure.Repository;
using Utilities;

namespace CashRegisterDesktopApp.ViewModel
{
    public class AddToInventoryViewModel : BaseViewModel
    {
        private string _itemName;
        private string _itemVariationName;
        private int _inventory;
        private decimal _basePrice;
        private string _sku;
        private string _currentScannedSku;
        private IRepository<Item> _repo;
        
        public ObservableCollection<InventoryItemViewModel> InventoryItems { get; set; }

        public AddToInventoryViewModel()
        {
            _repo = new InMemoryRepository();
        }

        public AddToInventoryViewModel(IRepository<Item> repo)
        {
            _repo = repo;
        }

        private void intialize()
        {
            
        }


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
