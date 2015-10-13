using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CashRegister.Core.Connection;
using Dapper;
using Utilities;

namespace DapperDataAccess
{
    public abstract class BaseRepository<TDataModel, TKeyType>
    {
        public string TableName { get; }
        public string PrimaryKey { get; }
        public IConnectionProvider ConnectionProvider { get; set; }
        public IConnectionStringProvider ConnectionStringProvider { get; set; }

        protected BaseRepository(IConnectionProvider connectionProvider, IConnectionStringProvider connectionStringProvider)
        {
            ConnectionProvider = connectionProvider;
            ConnectionStringProvider = connectionStringProvider;
            TableName = typeof (TDataModel).GetTableAttribute().Name;
            PrimaryKey = typeof (TDataModel).GetColumnAttribute().Name;
        }

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

        public virtual void BatchDeleteWithTempTable(List<TKeyType> keys, string tableToDeleteFrom = null,
            string tableKeyToLink = null, string tempTableName = "BatchDeleteTemp", string tempTableColumnName = "Id")
        {
            if (tableToDeleteFrom == null) tableToDeleteFrom = TableName;
            if (tableKeyToLink == null) tableKeyToLink = PrimaryKey;

            using (var connection =
                (SqlConnection)ConnectionProvider.GetConnection(ConnectionStringProvider.GetConnectionString()))
            {
                // Create temp table
                connection.Execute($"CREATE TABLE #{tempTableName} ({tempTableColumnName} UNIQUEIDENTIFIER PRIMARY KEY)");
                // Bulk Copy Operation
                using (var bulkCopyOp = new SqlBulkCopy(connection))
                {
                    // Set up particulars
                    bulkCopyOp.BatchSize = keys.Count();
                    bulkCopyOp.DestinationTableName = tempTableName;
                    // Make a new DataTable
                    var table = new DataTable();
                    // Add the DataTable schema
                    table.Columns.Add(tempTableColumnName, typeof(Guid));
                    bulkCopyOp.ColumnMappings.Add(tempTableColumnName, tempTableColumnName);
                    // Add all keys to DataTable
                    foreach (var key in keys) table.Rows.Add(key);
                    // Copy DataTable to Sql Temp Table
                    bulkCopyOp.WriteToServer(table);
                }
                // FINALLY, delete this shit.
                connection.Execute($"DELETE FROM {tableToDeleteFrom} WHERE {tableKeyToLink} IN " +
                                   $"(SELECT {tempTableColumnName} FROM {tempTableName})");
                // clean up
                connection.Execute($"DROP TABLE #{tempTableName}");
            }
        }
    }
}