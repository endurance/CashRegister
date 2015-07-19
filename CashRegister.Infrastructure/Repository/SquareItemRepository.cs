using System;
using CashRegister.Core.Models;
using RestSharp;

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

        public void SaveItem(Item item)
        {
            request.AddJsonBody(item);
        }

        public Item GetItem(Guid id)
        {
            return new Item();
        }
    }



    public interface IRepository<TItem>
    {
        void SaveItem(TItem item);
        TItem GetItem(Guid id);
    }

}