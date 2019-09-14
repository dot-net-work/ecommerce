using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Abstractions.BLL;
using Ecommerce.Abstractions.Repositories;
using Ecommerce.BLL.Base;
using Ecommerce.Models;

namespace Ecommerce.BLL
{
    public class CustomerManager:Manager<Customer>,ICustomerManager
    {
        private ICustomerRepository _customerRepository;


        public CustomerManager(ICustomerRepository customerRepository):base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
      

        public ICollection<Customer> GetByAddress(string address)
        {
            return _customerRepository.GetByAddress(address);
        }
    }
}
