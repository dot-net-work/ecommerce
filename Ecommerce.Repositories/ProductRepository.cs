using System.Collections.Generic;
using System.Linq;
using Ecommerce.Abstractions.Repositories;
using Ecommerce.DatabaseContext;
using Ecommerce.Models;
using Ecommerce.Models.APIViewModels;
using Ecommerce.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class ProductRepository:EFRepository<Product>,IProductRepository
    {
        private EcommerceDbContext _db;

        public ProductRepository(DbContext db):base(db)
        {
            _db = db as EcommerceDbContext;
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _db.Products.Where(c => c.CategoryId == categoryId).ToList();
        }

        public ICollection<Product> GetByCriteria(ProductSearchCriteriaVM criteria)
        {
            var products = _db.Products.AsQueryable();
            if (criteria != null)
            {
                if (!string.IsNullOrEmpty(criteria.Name))
                {
                    products = products.Where(c => c.Name.ToLower().Contains(criteria.Name.ToLower()));
                }

                if (criteria.FromPrice > 0)
                {
                    products = products.Where(c => c.Price >= criteria.FromPrice);
                }

                if (criteria.ToPrice > 0)
                {
                    products = products.Where(c => c.Price <= criteria.ToPrice);
                }

                
            }

            return products.ToList();
        }

        
    }
}
