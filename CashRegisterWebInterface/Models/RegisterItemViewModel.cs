using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CashRegister.Core.Models;

namespace CashRegisterWebInterface.Models
{
    public class RegisterItemViewModel
    {
        public List<Item> Items { get; set; } = new List<Item>();

        public Item CurrentItem { get; set; }
    }
    
}