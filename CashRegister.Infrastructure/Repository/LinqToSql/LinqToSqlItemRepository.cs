using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using AutoMapper;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.DataContexts;
using CashRegister.Infrastructure.DataContexts.Mapping;
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
                // check if item exists
                if (db.ItemDbs.Any(i => i.Id == itemModel.Id)) throw new InvalidOperationException("Cannot add an Item that already exists. Item Id: " + itemModel.Id);

                var itemToHydrate = new ItemDb();
                itemToHydrate.MapToItemDbObject(itemModel);
                itemToHydrate.Id = itemModel.Id;
                db.ItemDbs.InsertOnSubmit(itemToHydrate);
                db.SubmitChanges();
            }
        }

        public void AddItemVariation(ItemVariation itemVariationModel)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                // check if variation already exists
                if(db.ItemVariationDbs.Any(i => i.Id == itemVariationModel.Id)) throw new InvalidOperationException("Cannot add a new Variation because it already exists. ItemVariation Id: " + itemVariationModel.Id);
                var itemToHydrate = new ItemVariationDb();
                itemToHydrate.MapToItemVariationDbObject(itemVariationModel);
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
                itemToUpdate.MapToItemDbObject(item);
                db.SubmitChanges();
            }
        }

        public void UpdateItemVariation(ItemVariation itemVariation)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var itemToUpdate = db.ItemVariationDbs.FirstOrDefault(itemDb => itemDb.Id == itemVariation.Id);
                if (itemToUpdate == null) return;
                itemToUpdate.MapToItemVariationDbObject(itemVariation);
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
                if (dbItem == null) return null;
                var item = new Item();
                item.MapToItemObject(dbItem);
                return item;
            }
        }

        public Item GetItem(ItemVariation variation)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var dbItemVariation = db.ItemVariationDbs.SingleOrDefault(i => i.Id == variation.Id);
                if (dbItemVariation == null) return null;
                var itemDb = dbItemVariation.ItemDb;
                return Mapping.MapToItemObject(itemDb);
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
                    select Mapping.MapToItemObject(item);

                return query.ToList();
            }
        }

        public List<ItemVariation> GetAllItemVariations()
        {
            throw new NotImplementedException();
        }

        private static Item HydratedItemWithSingleVariation(ItemVariationDb itemVariationDb)
        {
            var itemToHydrate = new Item();
            var itemVariationToHydrate = new ItemVariation();
            itemToHydrate.MapToItemObject(itemVariationDb.ItemDb);
            itemVariationToHydrate.MapToItemVariationObject(itemVariationDb);
            itemToHydrate.Variations.Add(itemVariationToHydrate);
            return itemToHydrate;
            //var itemToHydrate = Mapper.Map<Item>(itemVariationDb.ItemDb);
            //var itemVariationToHydrate = Mapper.Map<ItemVariation>(itemVariationDb);
            //itemToHydrate.Variations.Clear();
            //itemToHydrate.Variations.Add(itemVariationToHydrate);
            //return itemToHydrate;
        }
    }
}