using System.ComponentModel.DataAnnotations;

namespace NewShoppingCart.Models
{
    public class Payment
    {
        public int UserId { get; set; }
        
        [Required]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? ContactNumber { get; set; }
        [Required]
        public string? Address { get; set; }
        public int Amount { get; set; }
        
       
        
        
    }
}
