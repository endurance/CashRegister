using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Infrastructure.Repository
{
    public interface IMessage
    {
        string EndPoint { get; set; }
        RequestVerb Verb { get; }
        string Header { get; set; }
        string Body { get; set; }
    }

    public enum RequestVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}
