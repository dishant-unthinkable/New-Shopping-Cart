using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartBALObject
{
    public interface ILoginObject
    {
        int UserID { get; set; }
        [Required]
        [EmailAddress]
        string email { get; set; }
        [Required(ErrorMessage = "please write password")]
        [MinLength(8)]
        string password { get; set; }
        bool IsActive { get; set; }
        string Role { get; set; }
    }
}
