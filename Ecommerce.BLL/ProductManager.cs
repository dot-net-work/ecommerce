using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Abstractions.BLL;
using Ecommerce.Abstractions.Repositories;
using Ecommerce.Abstractions.Repositories.Base;
using Ecommerce.BLL.Base;
using Ecommerce.Models;

namespace Ecommerce.BLL
{
    public class ProductManager:Manager<Product>,IProductManager
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository repository) : base(repository)
        {
            _productRepository = repository;
        }
    }
}
