using System.ComponentModel;

namespace CashRegister.Core.Models.Enums
{
    public enum ItemType
    {
        [Description("Normal")] NORMAL,
        [Description("Gift Card")] GIFT_CARD,
        [Description("Normal")] OTHER
    }
}