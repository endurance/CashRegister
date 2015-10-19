using System.Collections.Generic;
using CashRegister.Core.Models;

namespace CashRegister.Core.Service
{
    public interface IService<TModelType, TKeyType> where TModelType : IDataModel<TKeyType>
    {
        TModelType Get(TKeyType key);
        IEnumerable<TModelType> GetAll();
        void Insert(TModelType model);
        void Update(TModelType model);
        void Delete(TKeyType key);
    }

}