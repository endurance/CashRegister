using System;
using System.Collections.Generic;
using System.Linq;
using CashRegister.Core.Models;
using CashRegister.Core.Repository;
using CashRegister.Core.Service;

namespace Services
{
    public class ItemService : BaseService<IItemRepository, Item, Guid>, IItemService
    {
        public ItemService(IItemRepository repository, IItemVariationRepository itemVariationRepository)
            : base(repository)
        {
            ItemVariationRepository = itemVariationRepository;
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
                group new {variation} by item
                into g
                let item = g.Key
                let inventory = g.Sum(i => i.variation.Quantity)
                select new {Key = item, Sum = inventory};

            return query.ToDictionary(prop1 => prop1.Key, prop2 => prop2.Sum);
        }

        public IDictionary<Item, int> GetWithInventoryCount(Guid id)
        {
            var item = Repository.Get(id);
            var variations = ItemVariationRepository.GetAllItemVariationsBasedOnItem(id).ToList();
            var inventory =
                (from variation in variations
                select variation.Quantity).Sum();
            return new Dictionary<Item, int>()
            {
                { item, inventory }
            };
                
        }

        public void DeleteItem(Guid id)
        {
            // delete all of the variations of this item
            ItemVariationRepository.DeleteAllVariationsByItem(id);
            // finally delete this item
            Repository.Delete(id);
        }
    }
}