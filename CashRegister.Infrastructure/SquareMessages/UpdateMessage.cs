using CashRegister.Core.Models;
using CashRegister.Infrastructure.Repository;

namespace CashRegister.Infrastructure.SquareMessages
{
    public class UpdateMessage : IMessage
    {
        public UpdateMessage(IItem item)
        {
            Item = item;
        }

        public IItem Item { get; set; }

        public string EndPoint
        {
            get { return "https://connect.squareup.com"; }
            set { }
        }

        public RequestVerb Verb
        {
            get { return RequestVerb.POST; }
        }

        public string Header { get; set; }
        public string Body { get; set; }
    }
}