using System;
using System.Collections.Generic;
using CashRegister.Core.Models;

namespace CashRegister.Core.Service
{
    public interface IItemVariationService : IService<ItemVariation, Guid>
    {
        IEnumerable<ItemVariation> GetAllVariationsBasedOnItemKey(Guid itemKey);
        void DeleteBatch(IEnumerable<Guid> variationKeys);
        void DeleteBatch(IEnumerable<ItemVariation> variations);
    }
}