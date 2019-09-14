using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Abstractions.Repositories.Base;

namespace Ecommerce.Abstractions.Repositories
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        ICollection<Customer> GetByAddress(string address);
    }
}
