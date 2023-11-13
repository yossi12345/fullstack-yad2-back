using System.ComponentModel.DataAnnotations;

namespace yad2_back.Models
{
    public class ApartmentTypeModel
    {
        [Required,Key]
        public string Name {  get; set; }
    }
}
