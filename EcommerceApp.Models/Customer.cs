using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please provide Name!")]
        public string Name { get; set; }
          [Required]
        public string Address { get; set; }

        [Required]
        public int LoyaltyPoint { get; set; }
    }
}
