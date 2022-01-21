using System.ComponentModel.DataAnnotations;
namespace ShoppingCart.Models
{
    public class Contact
    {
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        [MaxLength(10)]
        public int ContactNo { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Description { get; set; }
    }
}
