using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Models.APIViewModels
{
    public class ProductSearchCriteriaVM
    {
        public string Name { get; set; }
        public double FromPrice { get; set; }
        public double ToPrice { get; set; }
    }
}
