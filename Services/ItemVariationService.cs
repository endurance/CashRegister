using System;
using System.Collections.Generic;
using CashRegister.Core.Models;
using CashRegister.Core.Service;
using DapperDataAccess;

namespace Services
{
    public class ItemVariationService : BaseService<ItemVariationRepository, ItemVariation, Guid>, IItemVariationService
    {
        public IEnumerable<ItemVariation> GetAllVariationsBasedOnItemKey(Guid itemKey)
        {
            return Repository.GetAllItemVariationsBasedOnItem(itemKey);
        }

        public ItemVariationService(ItemVariationRepository repository) : base(repository)
        {
        }
    }
}