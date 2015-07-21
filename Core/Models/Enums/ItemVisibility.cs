using System.ComponentModel;

namespace CashRegister.Core.Models.Enums
{
    public enum ItemVisibility
    {
        [Description("Visible")] PUBLIC,
        [Description("Invisible")] PRIVATE
    }
}