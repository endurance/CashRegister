using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DataAccess
{
    public abstract class BaseRepository<TObject> : IRepository
    {
        public string ConnectionString { get; set; }

        public virtual DbConnection GetDbConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
        public virtual TObject Get(Guid id)
        {
            using (var connection = GetDbConnection(ConnectionString))
            {
                return connection.Get<TObject>(id);
            }
        }

        public virtual List<TObject> GetAll()
        {
            using (var connection = GetDbConnection(ConnectionString))
            {
                return connection.GetList<TObject>().ToList();
            }
        } 

        public virtual void Insert(TObject obj)
        {
            using (var connection = GetDbConnection(ConnectionString))
            {
                connection.Insert<TObject>(obj);
            }
        }

        public virtual void Update(TObject obj)
        {
            using (var connection = GetDbConnection(ConnectionString))
            {
                connection.Update(obj);
            }
        }

        public virtual void Delete(TObject obj)
        {
            using (var connection = GetDbConnection(ConnectionString))
            {
                connection.Delete(obj);
            }
        }
    }
}