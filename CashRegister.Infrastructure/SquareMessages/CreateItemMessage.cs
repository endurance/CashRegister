using CashRegister.Infrastructure.Repository;
using RestSharp;

namespace CashRegister.Infrastructure.SquareMessages
{
    internal class CreateItemMessage : IMessage
    {
        public string BaseUrl
        {
            get { return "https://connect.squareup.com"; }
        }
        public string Resource { get { return "/v1/me/items/"; } }
        public string Endpoint { get { return BaseUrl + Resource; } }
        public Method HttpType { get { return Method.POST; } }
    }
}