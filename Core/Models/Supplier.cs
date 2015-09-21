using System;

namespace CashRegister.Core.Models
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string MainPhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
    }
}