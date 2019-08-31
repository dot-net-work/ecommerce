using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Customer
    {
        public Customer()
        {
          
        }
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please provide Name!")]
        public string Name { get; set; }
          [Required]
        public string Address { get; set; }

        [Required]
        public int LoyaltyPoint { get; set; }
        
    }
}
