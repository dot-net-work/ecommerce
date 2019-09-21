using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Ecommerce.Models;
using Ecommerce.Models.RazorViewModels.Customer;

namespace Ecommerce.Configurations.AutomapperConfigurations
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CustomerCreateViewModel, Customer>();
            CreateMap<Customer, CustomerCreateViewModel>();

        }
    }
}
