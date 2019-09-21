using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Abstractions.BLL;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApp.Controllers.API
{
    [ApiController]
    public class ProductController:ControllerBase
    {
        private IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet("api/products/")]
        public ICollection<Product> Get()
        {
            return _productManager.GetAll().ToList();
        }

        [HttpGet("api/products/{id}")]
        public Product Get(long id)
        {
            return _productManager.GetById(id);
        }
    }
}
