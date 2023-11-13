using System.ComponentModel.DataAnnotations;

namespace yad2_back.Models
{
    public class ImageModel
    {
        [Required,Key]
        public string ImagePath { get; set; }
    }
}
