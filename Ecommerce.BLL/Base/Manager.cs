using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Abstractions.BLL.Base;
using Ecommerce.Abstractions.Repositories.Base;

namespace Ecommerce.BLL.Base
{
    public abstract class Manager<T>:IManager<T> where T:class
    {
        private IRepository<T> _repository;

        public Manager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual bool Add(T entity)
        {
            return _repository.Add(entity);
        }

        public virtual ICollection<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual T GetById(long id)
        {
            return _repository.GetById(id);
        }

        public virtual bool Update(T entity)
        {
            return _repository.Update(entity);
        }

        public virtual bool Remove(T entity)
        {
            return _repository.Remove(entity);
        }
    }
}
