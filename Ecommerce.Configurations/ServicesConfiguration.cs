using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Abstractions.BLL;
using Ecommerce.Abstractions.Repositories;
using Ecommerce.BLL;
using Ecommerce.DatabaseContext;
using Ecommerce.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Configurations
{
    public class ServicesConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<DbContext, EcommerceDbContext>();
        }
    }
}
