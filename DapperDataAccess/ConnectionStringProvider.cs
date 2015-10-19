using System.Configuration;
using CashRegister.Core.Connection;

namespace DapperDataAccess
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public string GetConnectionString(string name = null)
        {
            return name == null ? ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString : ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}