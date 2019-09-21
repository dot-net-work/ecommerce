using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.Abstractions.BLL;
using Ecommerce.Abstractions.Repositories;
using Ecommerce.Abstractions.Repositories.Base;
using Ecommerce.BLL.Base;
using Ecommerce.Models;
using Ecommerce.Models.APIViewModels;

namespace Ecommerce.BLL
{
    public class ProductManager:Manager<Product>,IProductManager
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository repository) : base(repository)
        {
            _productRepository = repository;
        }

       

        
        public ICollection<Product> GetByCriteria(ProductSearchCriteriaVM criteria)
        {
            return _productRepository.GetByCriteria(criteria);
        }

        public override bool Remove(Product entity)
        {
            entity.IsActive = false;
            return _productRepository.Update(entity);
        }
    }
}
