using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApp.Controllers
{
    public class CustomerController:Controller
    {
        private CustomerRepository _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }
        public IActionResult Index()
        {
            var customers = _customerRepository.GetAll();
            return View(customers);
        }

        public IActionResult Create()
        {
            var customers = _customerRepository.GetAll();
            var model  = new Customer();
            model.CustomerList = customers;
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Customer model)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = _customerRepository.Add(model);
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
