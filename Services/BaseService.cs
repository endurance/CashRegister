using System.Collections.Generic;
using CashRegister.Core;
using CashRegister.Core.Models;
using CashRegister.Core.Repository;

namespace Services
{
    public abstract class BaseService<TRepositoryType, TModelType, TKeyType> 
        where TRepositoryType : IRepository<TModelType, TKeyType> 
        where TModelType : IDataModel<TKeyType>
    {
        protected TRepositoryType Repository { get; set; }
        public virtual TModelType Get(TKeyType key)
        {
            return Repository.Get(key);
        }

        public virtual IEnumerable<TModelType> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual void Insert(TModelType model)
        {
            Repository.Insert(model);
        }

        public virtual void Delete(TKeyType key)
        {
            Repository.Delete(key);
        }
    }
}