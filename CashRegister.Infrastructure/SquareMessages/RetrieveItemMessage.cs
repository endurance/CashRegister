using System;
using CashRegister.Infrastructure.Repository;
using RestSharp;

namespace CashRegister.Infrastructure.SquareMessages
{
    internal class RetrieveItemMessage : IMessage
    {
        public Guid Item_Id { get; set; }
        public string BaseUrl
        {
            get { return "https://connect.squareup.com"; }
        }
        public string Resource { get { return "/v1/me/items/" + Item_Id; } }
        public string Endpoint { get { return BaseUrl + Resource; } }
        public Method HttpType { get { return Method.GET; } }
    }
}