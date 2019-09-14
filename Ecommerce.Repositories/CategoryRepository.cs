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

        public CategoryRepository(EcommerceDbContext db):base(db)
        {
            _db = db;
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
