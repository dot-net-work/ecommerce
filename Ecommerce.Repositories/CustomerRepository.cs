using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.DatabaseContext;
using Ecommerce.Models;

namespace Ecommerce.Repositories
{
    public class CustomerRepository
    {
        private EcommerceDbContext _db;

        public CustomerRepository()
        {
            _db = new EcommerceDbContext();
        }
        public bool Add(Customer customer)
        {
            _db.Customers.Add(customer);
            return _db.SaveChanges() > 0;
        }
    }
}
