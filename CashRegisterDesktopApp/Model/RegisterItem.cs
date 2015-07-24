using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.Core.Models;

namespace CashRegisterDesktopApp.Model
{
    public class RegisterItem : Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
    }
}
