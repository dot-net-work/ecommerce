using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.Abstractions.Repositories;
using Ecommerce.DatabaseContext;
using Ecommerce.Models;
using Ecommerce.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class CustomerRepository:EFRepository<Customer>,ICustomerRepository
    {
        private EcommerceDbContext _db;


        public CustomerRepository(EcommerceDbContext db) : base(db)
        {
            _db = db;
        }
        public ICollection<Customer> GetByAddress(string address)
        {
            return _db.Customers.Where(c => c.Address.Contains(address)).ToList();
        }
    }
}
