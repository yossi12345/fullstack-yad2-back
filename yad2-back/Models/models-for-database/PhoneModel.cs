using System.ComponentModel.DataAnnotations;

namespace yad2_back.Models
{
    public class PhoneModel
    {
        [Key]
        public int Id { get; set; }
        [Required,RegularExpression(@"^(050|052|053|054|057|058)-\d{7}$")]
        public string Phone { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
