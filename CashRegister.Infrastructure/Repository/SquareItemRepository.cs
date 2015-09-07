using System;
using System.Collections.Generic;
using System.Linq;
using CashRegister.Infrastructure.Models;
using CashRegister.Infrastructure.SquareMessages;
using RestSharp;
using Utilities;

namespace CashRegister.Infrastructure.Repository
{
    public class SquareItemRepository
    {
        private const string Access_Token = "DUxLfvEGFS2CAuW0J1CZ1Q";
        private const string EndPoint = "https://connect.squareup.com";
        private readonly RestClient _restClient;

        public SquareItemRepository()
        {
            _restClient = new RestClient(EndPoint);
        }

        public void AddItem(SquareItem squareItem)
        {
            var request = getPopulatedRequest(new CreateItemMessage());
            _restClient.Post(request);
        }

        public void UpdateItem(SquareItem squareItem)
        {
            DeleteItem(squareItem.Id);
            AddItem(squareItem);
        }

        public SquareItem GetItemById(Guid id)
        {
            var msg = new RetrieveItemMessage {Item_Id = id};
            var request = getPopulatedRequest(msg);
            var item = _restClient.Execute<SquareItem>(request);

            return item.Data;
        }

        public SquareItem GetItemBySku(string sku)
        {
            var items = GetAllItems();
            return items.FirstOrDefault(item => item.Variations
                .Any(variation => variation.Sku.Equals(sku)));
        }

        public void DeleteItem(Guid id)
        {
            var msg = new DeleteItemMessage {Item_Id = id};
            var request = getPopulatedRequest(msg);
            _restClient.Delete(request);
        }

        public List<SquareItem> GetAllItems()
        {
            var request = getPopulatedRequest(new ListItemsMessage());
            return _restClient.Execute<List<SquareItem>>(request).Data;
        }

        private RestRequest getPopulatedRequest(IMessage msg)
        {
            var request = new RestRequest(msg.Resource, msg.HttpType)
            {
                JsonSerializer = new RestSharpJsonNetSerializer()
            };
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