using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using AutoMapper;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.DataContexts;
using CashRegister.Infrastructure.Interfaces;

namespace CashRegister.Infrastructure.Repository
{
    public class LinqToSqlItemRepository : IRepository
    {
        public LinqToSqlItemRepository()
        {
            Mapper.CreateMap<Item, ItemDb>()
                .ForMember(i => i.Id, opt=> opt.Ignore())
                .ForMember(i => i.ItemVariationDbs, m => m.Ignore());
            Mapper.CreateMap<ItemDb, Item>()
                .ForMember(i => i.Variations, m => m.MapFrom(s => s.ItemVariationDbs));

            Mapper.CreateMap<ItemVariation, ItemVariationDb>();
            Mapper.CreateMap<ItemVariationDb, ItemVariation>();
        }

        public string ConnectionString { get; set; }

        public void AddItem(Item itemModel)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var itemToHydrate = Mapper.Map<ItemDb>(itemModel);
                itemToHydrate.Id = itemModel.Id;
                db.ItemDbs.InsertOnSubmit(itemToHydrate);
                db.SubmitChanges();
            }
        }

        public void AddItemVariation(ItemVariation itemVariationModel)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var itemToHydrate = Mapper.Map<ItemVariationDb>(itemVariationModel);
                itemToHydrate.Id = itemVariationModel.Id;
                db.ItemVariationDbs.InsertOnSubmit(itemToHydrate);
                db.SubmitChanges();
            }
        }

        public void UpdateItem(Item item)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var itemToUpdate = db.ItemDbs.FirstOrDefault(itemDb => itemDb.Id == item.Id);
                if (itemToUpdate == null) return;
                Mapper.Map(item, itemToUpdate);
                db.SubmitChanges();
            }
        }

        public void UpdateItemVariation(ItemVariation itemVariation)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var itemToUpdate = db.ItemVariationDbs.FirstOrDefault(itemDb => itemDb.Id == itemVariation.Id);
                if (itemToUpdate == null) return;
                Mapper.Map(itemVariation, itemToUpdate);
                db.SubmitChanges();
            }
        }

        public void DeleteItem(Item item)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var itemToDelete = db.ItemDbs.FirstOrDefault(itemDb => itemDb.Id == item.Id);
                if (itemToDelete == null) return;
                foreach (var variation in itemToDelete.ItemVariationDbs)
                {
                    db.ItemVariationDbs.DeleteOnSubmit(variation);
                }
                db.ItemDbs.DeleteOnSubmit(itemToDelete);

                db.SubmitChanges();
            }
        }

        public void DeleteItemVariation(Item itemVariation)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var itemToDelete = db.ItemVariationDbs.FirstOrDefault(itemVariationDbs => itemVariationDbs.Id == itemVariation.Id);
                if (itemToDelete == null) return;
                db.ItemVariationDbs.DeleteOnSubmit(itemToDelete);
                db.SubmitChanges();
            }
        }

        public Item GetItem(Guid id)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var dbItem = db.ItemDbs.SingleOrDefault(i => i.Id == id);
                return dbItem == null ? null : Mapper.Map<Item>(dbItem);
            }
        }

        public Item GetItem(ItemVariation variation)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var dbItemVariation = db.ItemVariationDbs.SingleOrDefault(i => i.Id == variation.Id);
                return dbItemVariation == null ? null : Mapper.Map<Item>(dbItemVariation.ItemDb);
            }
        }

        public Item GetVariation(Guid id)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var itemVariationDb = db.ItemVariationDbs.SingleOrDefault(i => i.Id == id);
                if (itemVariationDb == null) return null;

                var itemToHydrate = HydratedItemWithSingleVariation(itemVariationDb);

                return itemToHydrate;
            }
        }

        public Item GetVariation(string sku)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var itemVariationDb = db.ItemVariationDbs.SingleOrDefault(i => i.Sku == sku);
                if (itemVariationDb == null) return null;

                var itemToHydrate = HydratedItemWithSingleVariation(itemVariationDb);

                return itemToHydrate;
            }
        }

        public List<Item> GetAllItems()
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var query = from item in db.ItemDbs
                    select Mapper.Map<Item>(item);

                return query.ToList();
            }
        }

        public List<ItemVariation> GetAllItemVariations()
        {
            throw new NotImplementedException();
        }

        private static Item HydratedItemWithSingleVariation(ItemVariationDb itemVariationDb)
        {
            var itemToHydrate = Mapper.Map<Item>(itemVariationDb.ItemDb);
            var itemVariationToHydrate = Mapper.Map<ItemVariation>(itemVariationDb);
            itemToHydrate.Variations.Clear();
            itemToHydrate.Variations.Add(itemVariationToHydrate);
            return itemToHydrate;
        }
    }
}