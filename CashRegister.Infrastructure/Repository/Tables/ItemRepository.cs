using CashRegister.Core.Models;
using CashRegister.Infrastructure.Repository.Abstract;

namespace CashRegister.Infrastructure.Repository.Tables
{
    public class ItemRepository : DapperCrudRepository<Item>
    {
    }
}