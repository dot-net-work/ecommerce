using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Abstractions.BLL;
using Ecommerce.BLL;
using Ecommerce.Models;
using Ecommerce.Repositories;
using Ecommerce.WebApp.Models.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApp.Controllers
{
    public class CustomerController:Controller
    {
        private ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        public IActionResult Index()
        {
            var customers = _customerManager.GetAll();
            return View(customers);
        }

        public IActionResult Create()
        {
            var customers = _customerManager.GetAll();
            var model  = new CustomerCreateViewModel();
            model.CustomerList = customers.ToList();
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

                bool isAdded = _customerManager.Add(customer);
                if (isAdded)
                {
                    ViewBag.SuccessMessage = "Saved Successfully!";
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Operation Failed!";
            }
            
            model.CustomerList = _customerManager.GetAll().ToList(); ;
            return View(model);
        }


        public PartialViewResult CustomerListPartial()
        {
            var customers = _customerManager.GetAll();
            return PartialView("Customer/_CustomerList", customers);
        }
    }
}
