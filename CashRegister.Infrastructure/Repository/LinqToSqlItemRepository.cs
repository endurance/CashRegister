using System;
using System.Collections.Generic;
using System.Linq;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.DataContexts;
using CashRegister.Infrastructure.DataContexts.Mapping;
using CashRegister.Infrastructure.Interfaces;

namespace CashRegister.Infrastructure.Repository
{
    public class LinqToSqlItemRepository : IRepository
    {
        public string ConnectionString { get; set; }

        public void AddItem(Item obj)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var itemToHydrate = new ItemDb();
                itemToHydrate.MapObject(obj);
                db.ItemDbs.InsertOnSubmit(itemToHydrate);
                db.SubmitChanges();
            }
        }

        public void AddItemVariation(ItemVariation itemVariation)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var itemToHydrate = new ItemVariationDb();
                itemToHydrate.MapObject(itemVariation);
                db.ItemVariationDbs.InsertOnSubmit(itemToHydrate);
                db.SubmitChanges();
            }
        }

        public void UpdateItem(Item item)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var findItem = db.ItemDbs.Where(i => i.Id == item.Id);
                findItem.MapObject(item);
                db.SubmitChanges();
            }
        }

        public void UpdateItemVariation(ItemVariation itemVariation)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var findItem = db.ItemDbs.Where(i => i.Id == itemVariation.Id);
                findItem.MapObject(itemVariation);
                db.SubmitChanges();
            }
        }

        public void DeleteItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItemVariation(Item itemVariation)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var itemModel = new Item();
                var variationModel = new ItemVariation();

                var dbItem = db.ItemDbs.SingleOrDefault(i => i.Id == id);
                if (dbItem == null) return null;

                itemModel.MapObject(dbItem);
                foreach (var variation in dbItem.ItemVariationDbs)
                {
                    variationModel.MapObject(variation);
                    itemModel.Variations.Add(variationModel);
                }

                return itemModel;
            }
        }

        public Item GetItem(ItemVariation variation)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var query = db.ItemVariationDbs.SingleOrDefault(i => i.Id == variation.Id);
                if (query == null) return null;

                var itemDb = db.ItemVariationDbs.SingleOrDefault(i => i.Id == variation.Id);

                var itemModel = new Item();
                itemModel.MapObject(itemDb);
                return itemModel;
            }
        }

        public Item GetVariation(Guid id)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var itemVariationDb = db.ItemVariationDbs.SingleOrDefault(i => i.Id == id);
                if (itemVariationDb == null) return null;

                var itemModel = new Item();
                var variationModel = new ItemVariation();
                itemModel.MapObject(itemVariationDb.ItemDb);
                variationModel.MapObject(itemVariationDb);
                itemModel.Variations.Add(variationModel);

                return itemModel;
            }
        }

        public Item GetVariation(string sku)
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var itemVariationDb = db.ItemVariationDbs.SingleOrDefault(i => i.Sku == sku);
                if (itemVariationDb == null) return null;

                var itemModel = new Item();
                var variationModel = new ItemVariation();
                itemModel.MapObject(itemVariationDb.ItemDb);
                variationModel.MapObject(itemVariationDb);
                itemModel.Variations.Add(variationModel);

                return itemModel;
            }
        }

        public List<Item> GetAllItems()
        {
            using (var db = new ItemsDataContext(ConnectionString))
            {
                var items = new List<Item>();
                var itemDbs = db.ItemDbs.ToList();
                var itemModel = new Item();
                var variationModel = new ItemVariation();
                foreach (var dbItem in itemDbs)
                {
                    itemModel.MapObject(dbItem);
                    foreach (var dbVariation in dbItem.ItemVariationDbs)
                    {
                        variationModel.MapObject(dbVariation);
                        itemModel.Variations.Add(variationModel);
                    }
                    items.Add(itemModel);
                }

                return items;
            }
        }

        public List<ItemVariation> GetAllItemVariations()
        {
            throw new NotImplementedException();
        }
    }
}