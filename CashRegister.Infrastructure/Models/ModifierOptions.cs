using System;

namespace CashRegister.Core.Models
{
    public class ModifierOptions
    {
        //The modifier option's unique ID
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Money Price_Money { get; set; }
        public bool On_By_Default { get; set; }
        public int Ordinal { get; set; }
        // The ID of the modifier list the option belongs to.
        public Guid Modifier_List_Id { get; set; }
    }
}