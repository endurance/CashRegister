using System.Data.Entity.Migrations;
using CashRegisterWebUI.Models;
using Microsoft.AspNet.Identity;

namespace CashRegisterWebUI.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CashRegisterWebUI.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var passwordHash = new PasswordHasher();
            var password = passwordHash.HashPassword("endurance");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "endurance",
                    PasswordHash = password
                });
        }
    }
}