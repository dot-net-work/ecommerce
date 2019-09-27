using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Abstractions.Repositories.Base;
using Ecommerce.Models;

namespace Ecommerce.Abstractions.Repositories
{
    public interface ICategoryRepository:IRepository<Category>
    {
    }
}
