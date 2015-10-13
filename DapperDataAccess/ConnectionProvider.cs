using System.Data.Common;
using System.Data.SqlClient;
using CashRegister.Core.Connection;

namespace DapperDataAccess
{
    public class ConnectionProvider : IConnectionProvider
    {
        public DbConnection GetConnection(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}