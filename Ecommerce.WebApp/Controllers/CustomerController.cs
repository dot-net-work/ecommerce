using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Repositories;
using Ecommerce.WebApp.Models.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApp.Controllers
{
    public class CustomerController:Controller
    {
        private CustomerRepository _customerRepository;

        public CustomerController(CustomerRepository repository)
        {
            _customerRepository = repository;
        }
        public IActionResult Index()
        {
            var customers = _customerRepository.GetAll();
            return View(customers);
        }

        public IActionResult Create()
        {
            var customers = _customerRepository.GetAll();
            var model  = new CustomerCreateViewModel();
            model.CustomerList = customers;
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CustomerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer()
                {
                    Name=model.Name,
                    Address = model.Address,
                    LoyaltyPoint = model.LoyaltyPoint
                };

                bool isAdded = _customerRepository.Add(customer);
                if (isAdded)
                {
                    ViewBag.SuccessMessage = "Saved Successfully!";
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Operation Failed!";
            }
            
            model.CustomerList = _customerRepository.GetAll(); ;
            return View(model);
        }


        public PartialViewResult CustomerListPartial()
        {
            var customers = _customerRepository.GetAll();
            return PartialView("Customer/_CustomerList", customers);
        }
    }
}
