using System.ComponentModel.DataAnnotations;

namespace yad2_back.Models
{
    public class FeatureModel
    {
        [Required,Key]
        public string Name { get; set; }
    }
}
