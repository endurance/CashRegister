using System;
using System.Collections.Generic;
using CashRegister.Core.Models.Enums;

namespace CashRegister.Core.Models
{
    public class ModifierList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public SelectionType SelectionType { get; set; }
        public IEnumerable<ModifierOptions> Modifier_Options { get; set; }
    }
}