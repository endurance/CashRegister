using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CashRegisterDesktopApp.ViewModel;
using CashRegisterDesktopApp.Views.SubViews;
using Utilities;

namespace CashRegisterDesktopApp.Views
{
    /// <summary>
    ///     Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView
    {
        public CheckoutRegisterViewModel viewModel = new CheckoutRegisterViewModel();

        public RegisterView()
        {
            InitializeComponent();
            DataContext = viewModel;
            PreviewKeyDown += viewModel.Scanner.BeginScan;
        }
    }
}