using System.ComponentModel.DataAnnotations;

namespace yad2_back.Models
{
    public class SignupModel
    {
        [Required,RegularExpression(@"^[^0-9!@#$%^&*()]*$")]
        public string FirstName { get; set; }
        [Required, RegularExpression(@"^[^0-9!@#$%^&*()]*$")]
        public string LastName { get; set; }
        [Required, RegularExpression(@"^(050|052|053|054|057|058)-\d{7}$")]
        public string Phone { get; set; }
        [Required, EmailAddress]
        public string Mail { get; set; }
        [Required,RegularExpression(@"^(?=.*[0-9])(?=.*[a-zA-Z])[\w!@#$%^&*].{6,20}")]
        public string Password {  get; set; }
    }
}
