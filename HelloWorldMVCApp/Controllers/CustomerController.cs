using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldMVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldMVCApp.Controllers
{
    public class CustomerController : Controller
    {
        public string Index(List<Customer> customers)
        {
            string message = "";
            if (customers != null && customers.Any())
            {
                foreach (var customer in customers)
                {
                  message +=  $"{{ {customer.Name}, {customer.Address} Loyalty Point: {customer.LoyaltyPoint} }}"+Environment.NewLine;
                }
            }

            return message;

        }
    }
}