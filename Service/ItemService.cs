using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.Infrastructure.Repository;

namespace Service
{
    public class ItemService
    {
        private RegisterItemRepository repo = new RegisterItemRepository();

        public void GetSingleVariation(Guid itemVariationId)
        {
            repo.Get
        }
    }
}
