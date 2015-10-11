using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using CashRegister.Core.Connection;

namespace DapperDataAccess
{
    public class SqlConnectionProvider : IConnectionProvider
    {
        public DbConnection GetConnection(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }

    public class GeneralConnectionStringProvider : IConnectionStringProvider
    {
        public string GetConnectionString(string name = null)
        {
            if (name == null)
                return ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;

            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}