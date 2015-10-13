using System;
using System.Collections.Generic;
using System.Linq;
using CashRegister.Core.Connection;
using CashRegister.Core.Models;
using CashRegister.Core.Repository;
using Dapper;

namespace DapperDataAccess
{
    public class ItemVariationRepository : BaseRepository<ItemVariation, Guid>, IItemVariationRepository
    {
        public ItemVariationRepository(IConnectionProvider connectionProvider,
            IConnectionStringProvider connectionStringProvider) : base(connectionProvider, connectionStringProvider)
        {
        }

        public IEnumerable<ItemVariation> GetAllItemVariationsBasedOnItem(Guid itemKey)
        {
            string sql = $"SELECT * from ItemVariation where ItemVariation.ItemId = '{itemKey}'";
            using (var connection = ConnectionProvider.GetConnection(ConnectionStringProvider.GetConnectionString()))
            {
                return connection.Query(sql).Select(i => (ItemVariation) ItemVariationMapper.Map(i)).ToList();
            }
        }

        public void DeleteAllVariationsByItem(Guid itemKey)
        {
            using (var connection = ConnectionProvider.GetConnection(ConnectionStringProvider.GetConnectionString()))
            {
                connection.DeleteList<ItemVariation>($"WHERE ItemId = '{itemKey}'");
            }
        }

        public void DeleteBatch(IEnumerable<Guid> variationKeys)
        {
            var keys = variationKeys.ToList();
            BatchDeleteWithTempTable(keys);
        }

        public void DeleteBatch(IEnumerable<ItemVariation> variations)
        {
            DeleteBatch(variations.Select(i => i.Id).ToList());
        }
    }
}