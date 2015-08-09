using CashRegister.Core.Models;

namespace EntityFrameworkWithSqlLite
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    
    class DbInitializer : DropCreateDatabaseAlways<ItemDbContext>
    { }


    public class ItemDbContext : DbContext
    {
        // Your context has been configured to use a 'ItemDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EntityFrameworkWithSqlLite.ItemDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ItemDbContext' 
        // connection string in the application configuration file.
        static ItemDbContext()
        {
            // Database initialize
            Database.SetInitializer<ItemDbContext>(new DbInitializer());
            using (ItemDbContext db = new ItemDbContext())
                db.Database.Initialize(false);
        }
        public ItemDbContext()
            : base("name=ItemDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.


        public DbSet<Fee> Fee { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemCategory> ItemCategory { get; set; }
        public DbSet<ItemImage> ItemImage { get; set; }
        public DbSet<ItemList> ItemList { get; set; }
        public DbSet<ItemVariation> ItemVariation { get; set; }
        public DbSet<ModifierList> ModifierList { get; set; }
        public DbSet<ModifierOptions> ModifierOptions { get; set; }
        public DbSet<Money> Money { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}