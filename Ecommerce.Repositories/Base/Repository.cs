using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.Abstractions.Repositories.Base;
using Ecommerce.DatabaseContext;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories.Base
{
    public abstract class EFRepository<T>:IRepository<T> where T:class
    {
        private DbContext _db;

        public EFRepository(DbContext db)
        {
            _db = db;
        }
        public virtual bool Add(T entity)
        {
            _db.Set<T>().Add(entity);
            return _db.SaveChanges() > 0;
        }

        public virtual ICollection<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public virtual bool Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return _db.SaveChanges() > 0;
        }

        public virtual bool Remove(T entity)
        {
            _db.Set<T>().Remove(entity);

            return _db.SaveChanges() > 0;
        }

        public virtual T GetById(long id)
        {
           return _db.Set<T>().Find(id);
        }
    }
}
