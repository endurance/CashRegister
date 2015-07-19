using System;

namespace CashRegister.Core.Models
{
    public class ModifierOptions
    {
        //The modifier option's unique ID
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public Money Price { get; set; }
        public bool OnByDefault { get; set; }
        public int Ordinal { get; set; }
        // The ID of the modifier list the option belongs to.
        public Guid ModifierListId { get; set; }
    }
}