using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CashRegister.Core.Models;
using CashRegister.Core.Repository;
using Dapper;

namespace DapperDataAccess
{
    public class ItemVariationRepository : BaseRepository<ItemVariation, Guid>, IItemVariationRepository
    {
        public IEnumerable<ItemVariation> GetAllItemVariationsBasedOnItem(Guid itemKey)
        {
            string sql = $"SELECT * from ItemVariation where ItemVariation.VariationId = {itemKey}";
            using (var connection = ConnectionProvider.GetConnection(ConnectionStringProvider.GetConnectionString()))
            {
                return connection.Query<ItemVariation>(sql).ToList();
            }
        
        }

    }
}