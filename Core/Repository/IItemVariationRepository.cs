using System;
using System.Collections.Generic;
using CashRegister.Core.Models;

namespace CashRegister.Core.Repository
{
    public interface IItemVariationRepository : IRepository<ItemVariation, Guid>
    {
        IEnumerable<ItemVariation> GetAllItemVariationsBasedOnItem(Guid itemKey);
        void DeleteAllVariationsByItem(Guid itemKey);
        void DeleteBatch(IEnumerable<Guid> variationKeys);
        void DeleteBatch(IEnumerable<ItemVariation> variations);
    }
}