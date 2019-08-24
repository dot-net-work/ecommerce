using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceApp.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual  List<Product> Products { get; set; }

    }
}
