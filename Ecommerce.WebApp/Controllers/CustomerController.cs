using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Abstractions.BLL;
using Ecommerce.BLL;
using Ecommerce.Models;
using Ecommerce.Models.RazorViewModels.Customer;
using Ecommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApp.Controllers
{
    public class CustomerController:Controller
    {
        private ICustomerManager _customerManager;
        private IMapper _mapper;

        public CustomerController(ICustomerManager customerManager,IMapper mapper)
        {
            _customerManager = customerManager;
            _mapper = mapper;
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
                var customer = _mapper.Map<Customer>(model);

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

        public IActionResult Get()
        {
            var customers = _customerManager.GetAll();
            return Json(customers);
        }

        public PartialViewResult CustomerListPartial()
        {
            var customers = _customerManager.GetAll();
            return PartialView("Customer/_CustomerList", customers);
        }
    }
}
