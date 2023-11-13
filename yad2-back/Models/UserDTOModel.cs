using System.ComponentModel.DataAnnotations;

namespace yad2_back.Models
{
    public class UserDTOModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public List<ApartmentModel> ApartmentForSelling { get; set; } = new();
        public List<ApartmentModel> FavoriteApartments { get; set; } = new();
        public List<SearchModel> LastApartmentSearches { get; set; } = new();
        [Required, RegularExpression(@"^(050 | 052 | 053 | 054 | 057 | 058) -\d{7}$")]
        public string Phone { get; set; }
        [Required,EmailAddress]
        public string Mail {  get; set; }
        public string? Token {  get; set; }
    }
}
