using System.Collections.Generic;
using System.Linq;
using Ecommerce.DatabaseContext;
using Ecommerce.Models;
using Ecommerce.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class ProductRepository:EFRepository<Product>
    {
        private EcommerceDbContext _db;

        public ProductRepository(EcommerceDbContext db):base(db)
        {
            _db = db;
        }
        
        public List<Product> GetByCategory(int categoryId)
        {
            return _db.Products.Where(c => c.CategoryId == categoryId).ToList();
        }
    }
}
