using System.Data.Common;

namespace DataAccess
{
    public interface IRepository
    {
        string ConnectionString { get; set; }
        DbConnection GetDbConnection(string connectionString);
    }
}