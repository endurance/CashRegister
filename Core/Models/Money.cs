using CashRegister.Core.Models.Enums;

namespace CashRegister.Core.Models
{
    public class Money
    {
        public SupportedCurrency CurrencyCode { get; set; }
        public decimal Amount { get; set; }
    }
}