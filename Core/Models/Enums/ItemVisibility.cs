using System.ComponentModel;

namespace CashRegister.Core.Models
{
    public enum ItemVisibility
    {
        [Description("Visible")] PUBLIC,
        [Description("Invisible")] PRIVATE
    }
}