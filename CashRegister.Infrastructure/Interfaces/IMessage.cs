using RestSharp;

namespace CashRegister.Infrastructure.Repository
{
    public interface IMessage
    {
        string BaseUrl { get; }
        string Resource { get; }
        string Endpoint { get; }
        Method HttpType { get; }
    }
}