using CashRegister.Core.Models.Enums;
using Newtonsoft.Json;

namespace CashRegister.Core.Models
{
    public class Money
    {
        [JsonProperty("currency_code")]
        public SupportedCurrency CurrencyCode { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        public decimal Price
        {
            get { return Amount / 100; }
            set { Amount = (int)(value * 100); }
        }
    }
}