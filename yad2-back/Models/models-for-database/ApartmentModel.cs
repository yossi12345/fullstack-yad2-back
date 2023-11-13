using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yad2_back.Models
{
    public class ApartmentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public List<ImageModel>? ImagesPaths { get; set; }
        [Required,Range(1,int.MaxValue)]
        public int StreetNumber { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required, Range(100, int.MaxValue)]
        public int Price { get; set; }
        [Required, Range(0, 12.5)]
        public double AmountOfRooms { get; set; }
        [Required,Range(1,4)]
        public int AmountOfShowerRooms { get; set; }
        [Required]
        public ApartmentTypeModel Type { get; set; }
        public string Description { get; set; }
        [Required,Range(1,5)]//5=דרוש שיפוץ
        public int Condition { get; set; }
        public string? View { get; set; }
        public bool isRearAsset;//נכס עורפי
        public int? Floor { get; set; }
        public int? AmountOfFloorsInBuilding { get; set; }
        [Range(1,3)]
        public int? AmountOfParkingPlaces { get; set; }
        [Range(1,4)]
        public int? AmountOfBalcony { get; set; }//כמות מרפסות
        public List<FeatureModel>? Features { get; set; }
        public int? builtArea { get; set; }
        [Required,Range(1,int.MaxValue)]
        public int Area { get; set; }
        [Required]
        public DateTime EntryDate { get; set; }
        public bool? IsEntryDateFlexible=null;//false=מיידי true=גמיש
        [Required]
        public List<PhoneModel> Phones { get; set; }
        [Required,Range(1,3)]
        public int AdType { get; set; }//1=free
        public bool IsFrozen { get; set; }
        [Required]
        public UserModel Advertiser { get; set; }
    }
}
