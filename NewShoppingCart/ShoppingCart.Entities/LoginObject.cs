using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartBALObject
{
    public class LoginObject:ILoginObject
    {
        public int UserID { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage= "please write password")]
        [MinLength(8)]
        public string password { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
    }
}

