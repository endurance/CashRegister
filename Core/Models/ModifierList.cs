using System;
using System.Collections.Generic;

namespace CashRegister.Core.Models
{
    public class ModifierList
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public SelectionType SelectionType { get; set; }
        public IEnumerable<ModifierOptions> ModifierOptions { get; set; }
    }
}