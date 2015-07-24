using System;
using System.Collections.Generic;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.Interfaces;
using CashRegister.Infrastructure.SquareMessages;
using RestSharp;
using Utilities;

namespace CashRegister.Infrastructure.Repository
{
    public class SquareItemRepository : IRepository<Item>
    {
        private const string Access_Token = "DUxLfvEGFS2CAuW0J1CZ1Q";
        private const string EndPoint = "https://connect.squareup.com";
        private readonly RestClient _restClient;

        public SquareItemRepository()
        {
            _restClient = new RestClient(EndPoint);
        }

        public void AddItem(Item item)
        {
            var request = getPopulatedRequest(new CreateItemMessage());
            _restClient.Post(request);
        }

        public void UpdateItem(Item item)
        {
            DeleteItem(item.Id);
            AddItem(item);
        }

        public Item FindItem(Guid id)
        {
            var msg = new RetrieveItemMessage {Item_Id = id};
            var request = getPopulatedRequest(msg);
            var item = _restClient.Execute<Item>(request);
             
            return item.Data;
        }

        public int GetItemVariationQuantity(Guid itemId, Guid variationId)
        {
            var item = FindItem(itemId);
            var itemVariations = item.Variations;
            return itemVariations.Find(i => i.Id.Equals(variationId)).Ordinal;
        }

        public void DeleteItem(Guid id)
        {
            var msg = new DeleteItemMessage {Item_Id = id};
            var request = getPopulatedRequest(msg);
            _restClient.Delete(request);
        }

        public List<Item> GetAllItems()
        {
            var request = getPopulatedRequest(new ListItemsMessage());
            return _restClient.Execute<List<Item>>(request).Data;
        }

        private RestRequest getPopulatedRequest(IMessage msg)
        {
            var request = new RestRequest(msg.Resource, msg.HttpType) {JsonSerializer = new RestSharpJsonNetSerializer()};
            restRequestSetup(request);
            return request;
        }

        private void restRequestSetup(RestRequest request)
        {
            // Standard header for square connect api requests
            request.AddHeader("Authorization", "Bearer " + Access_Token);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
        }
    }
}