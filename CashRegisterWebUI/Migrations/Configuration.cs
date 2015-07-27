using CashRegisterWebUI.Models;
using Microsoft.AspNet.Identity;

namespace CashRegisterWebUI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CashRegisterWebUI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CashRegisterWebUI.Models.ApplicationDbContext";
        }

        protected override void Seed(CashRegisterWebUI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("Password");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "Idehen",
                    PasswordHash = password,

                });
        }
    }
}
