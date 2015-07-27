using System.Security.Policy;
using System.Windows;
using CashRegisterDesktopApp.ViewModel;

namespace CashRegisterDesktopApp.Views.SubViews
{
    /// <summary>
    ///     Interaction logic for ModifyItemRegisterView.xaml
    /// </summary>
    public partial class ModifyItemRegisterView : Window
    {
        private readonly ModifyItemViewModel _vm;
        public ModifyItemRegisterView(CartItemViewModel currentItem)
        {
            InitializeComponent();
            _vm = new ModifyItemViewModel(currentItem);
            DataContext = _vm;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class ModifyItemViewModel : BaseViewModel
    {
        private readonly CartItemViewModel _cartItemToModify;

        public ModifyItemViewModel(CartItemViewModel viewModel)
        {
            _cartItemToModify = viewModel;
        }

        public string ItemName { get { return _cartItemToModify.Name; } }

        public int Quantity
        {
            get { return _cartItemToModify.Quantity; }
            set
            {
                _cartItemToModify.Quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
    }
}