using System.Collections.Generic;
using System.Linq;
using Ecommerce.Abstractions.Repositories;
using Ecommerce.DatabaseContext;
using Ecommerce.Models;
using Ecommerce.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class CategoryRepository:EFRepository<Category>,ICategoryRepository
    {
        private EcommerceDbContext _db;

        public CategoryRepository(DbContext db):base(db)
        {
            _db = db as EcommerceDbContext;
        }
    }
}
