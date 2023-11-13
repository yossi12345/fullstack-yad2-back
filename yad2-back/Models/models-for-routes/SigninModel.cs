using System.ComponentModel.DataAnnotations;

namespace yad2_back.Models
{
    public class SigninModel
    {
        [Required, EmailAddress]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
