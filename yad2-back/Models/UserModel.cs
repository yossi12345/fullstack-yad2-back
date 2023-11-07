using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace yad2_back.Models
{
    public class UserModel:IdentityUser
    {
        [Required]
        public string FirstName;
        [Required]
        public string LastName;
    }
}
