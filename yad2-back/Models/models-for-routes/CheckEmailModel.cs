using System.ComponentModel.DataAnnotations;

namespace yad2_back.Models.models_for_router
{
    public class CheckEmailModel
    {
        [Required, EmailAddress]
        public string Email {  get; set; }
    }
}
