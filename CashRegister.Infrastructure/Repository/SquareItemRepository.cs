using System;
using System.Collections.Generic;
using CashRegister.Core.Models;
using CashRegister.Core.Models.Interfaces;
using CashRegister.Infrastructure.SquareMessages;
using RestSharp;
using RestSharp.Serializers;

namespace CashRegister.Infrastructure.Repository
{
    public class SquareItemRepository : IRepository<Item>
    {
        private readonly RestRequest request;
        private const string Access_Token = "QY7A2IAniekH7j2oPb75_g";

        public SquareItemRepository()
        {
            request = new RestRequest();
            SetHeaders();
        }

        public void SetHeaders()
        {
            // Standard header for square connect api requests
            request.AddHeader("Authorization", "Bearer " + Access_Token);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
        }

        public void UpdateItem(UpdateMessage message)
        {
            var serialItem = new JsonSerializer();
            serialItem.Serialize(message.Item);

        }

        public Item FindItem(Guid id)
        {
            return new Item();
        }

        public List<IItem> GetAllItems(GetAllMessage message)
        {
            return new List<IItem>();
        }
    }



    public interface IRepository<TItem>
    {
        void UpdateItem(UpdateMessage message);
        TItem FindItem(Guid id);
    }

}