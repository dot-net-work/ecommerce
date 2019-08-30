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
            ViewBag.Customers = customers;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer model)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = _customerRepository.Add(model);
                if (isAdded)
                {
                    var customers = _customerRepository.GetAll();
                    ViewData["Customers"] = customers;
                    ViewBag.SuccessMessage = "Saved Successfully!";
                    return View("Index");
                }
            }
            return View();
        }

    }
}
