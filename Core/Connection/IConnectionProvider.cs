using System.Data.Common;

namespace CashRegister.Core.Connection
{
    public interface IConnectionProvider
    {
        DbConnection GetConnection(string connectionString);
    }
}