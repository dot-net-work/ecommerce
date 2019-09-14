using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Abstractions.BLL.Base
{
    public interface IManager<T> where T:class
    {
        bool Add(T entity);
        ICollection<T> GetAll();
        T GetById(long id);
        bool Update(T entity);
        bool Remove(T entity);
    }
}
