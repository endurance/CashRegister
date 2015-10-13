using System;
using System.Collections.Generic;
using System.Linq;
using CashRegister.Core.Models;
using CashRegister.Core.Repository;
using CashRegister.Core.Service;
using DapperDataAccess;

namespace Services
{
    public class ItemService : BaseService<IItemRepository, Item, Guid>, IItemService
    {
        public ItemService(IItemRepository repository, IItemVariationRepository itemVariationRepository) : base(repository)
        {
            this.ItemVariationRepository = itemVariationRepository;
        }

        private IItemVariationRepository ItemVariationRepository { get; }

        public IDictionary<Item, int> GetAllWithInventoryCounts()
        {
            // perform a get all
            var allItems = Repository.GetAll().ToList();
            var allVariations = ItemVariationRepository.GetAll().ToList();

            var query =
                from item in allItems
                from variation in allVariations
                where item.Id == variation.ItemId
                group variation by item.Id
                into g
                let id = g.Key
                let inv = g.Select(i => i.Quantity).Sum()
                from item in allItems
                where item.Id == id
                select new
                {
                    Key = item,
                    Sum = inv
                };

            return query.ToDictionary(prop1 => prop1.Key, prop2 => prop2.Sum);
        }

        public void DeleteItem(Guid id)
        {
            ItemVariationRepository.DeleteAllVariationsByItem(id);
            Repository.Delete(id);
        }
    }
}