using System.Collections.Generic;
using System.Windows.Documents;
using CashRegister.Core.Models;
using MahApps.Metro.Controls;

namespace CashRegisterDesktopApp.Views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView
    {
        public List<Item> Items { get; set; }
        public RegisterView()
        {
            Items = new List<Item>();
            DataContext = this;
            InitializeComponent();
            
        }
    }
}
