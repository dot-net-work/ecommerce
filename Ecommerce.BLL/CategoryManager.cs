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
    public class CategoryManager:Manager<Category>,ICategoryManager
    {
        private ICategoryRepository _repository;
        public CategoryManager(ICategoryRepository repository) : base(repository)
        {
            _repository = repository;

        }
    }
}
