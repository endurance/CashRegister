using System;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;

namespace CashRegister.Infrastructure.Repository.Abstract
{
    public abstract class DapperCrudRepository<TObjectType> 
    {
        public string ConnectionString { get; set; }

        public DbConnection ConnectionIntialize()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        public TObjectType GetObjectById(Guid id)
        {
            using (var connection = ConnectionIntialize())
            {
                return connection.Get<TObjectType>(id);
            }
        }

        public void InsertSupplier(TObjectType obj)
        {
            using (var connection = ConnectionIntialize())
            {
                connection.Insert<TObjectType>(obj);
            }
        }

        public void DeleteSupplier(TObjectType obj)
        {
            using (var connection = ConnectionIntialize())
            {
                connection.Delete(obj);
            }
        }

        public void UpdateObject(TObjectType obj)
        {
            using (var connection = ConnectionIntialize())
            {
                connection.Update(obj);
            }
        }
    }
}