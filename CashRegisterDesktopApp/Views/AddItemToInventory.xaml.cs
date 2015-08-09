using CashRegisterDesktopApp.ViewModel;
using MahApps.Metro.Controls;

namespace CashRegisterDesktopApp.Views
{
    /// <summary>
    ///     Interaction logic for AddItemToInventory.xaml
    /// </summary>
    public partial class AddItemToInventory : MetroContentControl
    {
        private AddToInventoryViewModel viewModel;

        public AddItemToInventory()
        {
            InitializeComponent();
            viewModel = new AddToInventoryViewModel();
        }
    }
}