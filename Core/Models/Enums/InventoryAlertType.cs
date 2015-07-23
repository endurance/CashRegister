using System.ComponentModel;

namespace CashRegister.Core.Models.Enums
{
    public enum InventoryAlertType
    {
        [Description("Low Inventory Quantity")] LOW_QUANTITY,
        [Description("No Alerts")] NONE
    }
}