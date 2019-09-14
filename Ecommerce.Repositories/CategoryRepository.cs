using System.Collections.Generic;
using System.Linq;
using Ecommerce.DatabaseContext;
using Ecommerce.Models;
using Ecommerce.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class CategoryRepository:EFRepository<Category>
    {
        private EcommerceDbContext _db;

        public CategoryRepository(DbContext db):base(db)
        {
            _db = db as EcommerceDbContext;
        }
        
        public void LoadProducts(Category category)
        {
            _db.Entry(category)
                .Collection(c=>c.Products)
                .Query()
                .Where(c=>c.IsActive)
                .Load();
         
        }
    }
}
