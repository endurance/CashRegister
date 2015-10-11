using System.Collections.Generic;
using System.Linq;
using CashRegister.Core.Connection;
using Dapper;

namespace DapperDataAccess
{
    public abstract class BaseRepository<TDataModel, TKeyType>
    {
        public IConnectionProvider ConnectionProvider { get; set; }
        public IConnectionStringProvider ConnectionStringProvider { get; set; }

        public virtual void Insert(TDataModel obj)
        {
            using (var connection = ConnectionProvider.GetConnection(ConnectionStringProvider.GetConnectionString()))
            {
                connection.Insert<TDataModel>(obj);
            }
        }

        public virtual void Update(TDataModel obj)
        {
            using (var connection = ConnectionProvider.GetConnection(ConnectionStringProvider.GetConnectionString()))
            {
                connection.Update(obj);
            }
        }

        public virtual void Delete(TKeyType obj)
        {
            using (var connection = ConnectionProvider.GetConnection(ConnectionStringProvider.GetConnectionString()))
            {
                connection.Delete(obj);
            }
        }

        public virtual TDataModel Get(TKeyType id)
        {
            using (var connection = ConnectionProvider.GetConnection(ConnectionStringProvider.GetConnectionString()))
            {
                return connection.Get<TDataModel>(id);
            }
        }

        public virtual IEnumerable<TDataModel> GetAll()
        {
            using (var connection = ConnectionProvider.GetConnection(ConnectionStringProvider.GetConnectionString()))
            {
                return connection.GetList<TDataModel>().ToList();
            }
        }
    }
}