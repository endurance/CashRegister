
using CashRegister.Core.Models;

namespace EntityFrameworkWithSqlLite
{
    static class MainProgram
    {
        static void Main(string[] args)
        {
            ItemDbContext context = new ItemDbContext();
            context.Item.Add(new Item());
            context.SaveChanges();
            
        }
    }
}
