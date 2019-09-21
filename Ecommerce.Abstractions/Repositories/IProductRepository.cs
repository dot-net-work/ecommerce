using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Abstractions.Repositories.Base;
using Ecommerce.Models;
using Ecommerce.Models.APIViewModels;

namespace Ecommerce.Abstractions.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
        ICollection<Product> GetByCriteria(ProductSearchCriteriaVM criteria);
    }
}
