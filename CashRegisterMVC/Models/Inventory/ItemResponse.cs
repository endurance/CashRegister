using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using CashRegister.Core.Models;

namespace CashRegisterMVC.Models.Inventory
{
    public class ItemResponse
    {
        [IgnoreDataMember]
        public Item ItemData { get; set; }
        public Guid Id => ItemData.Id;
        [DisplayName("Company Name")]
        public string CompanyName => ItemData.OriginalCompanyName.Trim();
        [DisplayName("Brand Name")]
        public string ItemBrandName => ItemData.BrandName.Trim();
        [DisplayName("Description")]
        public string Description => ItemData.Description.Trim();
        [DisplayName("Variation Quantity")]
        public int TotalInventory { get; set; }
    }
}