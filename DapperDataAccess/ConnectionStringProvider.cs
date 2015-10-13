using System.Configuration;
using CashRegister.Core.Connection;

namespace DapperDataAccess
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public string GetConnectionString(string name = null)
        {
            if (name == null)
                return ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;

            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}