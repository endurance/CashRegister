using CashRegister.Infrastructure.Repository;

namespace CashRegister.Infrastructure.SquareMessages
{
    public class GetAllMessage : IMessage
    {
        public string EndPoint
        {
            get { return "https://connect.squareup.com"; }
            set { }
        }

        public RequestVerb Verb
        {
            get { return RequestVerb.GET; }
        }

        public string Header
        {
            get { return null; }
            set { }
        }

        public string Body
        {
            get { return null; }
            set { }
        }
    }
}