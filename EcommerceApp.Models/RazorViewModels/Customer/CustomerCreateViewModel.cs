using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models.RazorViewModels.Customer
{
    public class CustomerCreateViewModel
    {
        [Required(ErrorMessage = "Please provide Name!")]
        public string Name { get; set; }
        [Required]
        [MaxLength(5)]
        [MinLength(2)]
        public string Address { get; set; }

        [Required]
        [Range(0,90)]
        public int LoyaltyPoint { get; set; }

        [NotMapped]
        public List<Ecommerce.Models.Customer> CustomerList { get; set; }
    }
}
