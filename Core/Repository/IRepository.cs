using System.Collections;
using System.Collections.Generic;
using CashRegister.Core.Models;

namespace CashRegister.Core.Repository
{
    public interface IRepository<TModel, TKeyType> where TModel : IDataModel<TKeyType>
    {
        TModel Get(TKeyType key);
        IEnumerable<TModel> GetAll();
        void Insert(TModel model);
        void Update(TModel model);
        void Delete(TKeyType key);
    }
}
