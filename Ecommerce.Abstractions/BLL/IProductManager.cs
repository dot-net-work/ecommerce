using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Abstractions.BLL.Base;
using Ecommerce.Models;
using Ecommerce.Models.APIViewModels;

namespace Ecommerce.Abstractions.BLL
{
   public interface IProductManager:IManager<Product>
    {
        ICollection<Product> GetByCriteria(ProductSearchCriteriaVM criteria);
    }
}
