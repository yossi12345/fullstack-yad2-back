using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yad2_back.Models
{
    public class UserModel:IdentityUser
    {
        [Required,RegularExpression(@"^[^0-9!@#$%^&*()]*$")]
        public string FirstName { get; set; }
        [Required,RegularExpression(@"^[^0-9!@#$%^&*()]*$")]
        public string LastName { get; set; }
        public List<ApartmentModel>? ApartmentForSelling { get; set; } 
        public List<ApartmentModel>? FavoriteApartments { get; set; } 
        public List<SearchModel>? LastApartmentSearches { get; set; }
    }
}
