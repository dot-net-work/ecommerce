using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Ecommerce.Models
{
    
    [Serializable]
   public class Product
    {
        public Product()
        {
            
        }

        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime? ExpireDate { get; set; }

        public bool IsActive { get; set; }  

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<ProductOrder> Orders { get; set; }

    }
}
