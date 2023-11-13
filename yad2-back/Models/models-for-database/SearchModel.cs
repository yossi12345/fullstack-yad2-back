using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yad2_back.Models
{
    public class SearchModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public List<ApartmentTypeModel>? AssetType { get; set; }
        [Range(100, int.MaxValue)]
        public int? MaxPrice { get; set; }
        [Range(100, int.MaxValue)]
        public int? MinPrice { get; set; }
        [Range(0,12.5)]
        public double? MinAmoutOfRooms { get; set; }
        [Range(0, 12.5)]
        public double? MaxAmoutOfRooms { get; set; }
        public List<FeatureModel>? Features { get; set; } = new();
        [Range(0, int.MaxValue)]
        public int? MinFloor { get; set; }
        [Range(0, int.MaxValue)]
        public int? MaxFloor { get; set; }
        public int? MinArea { get; set; }
        public int? MaxArea { get; set; }
        public DateTime? EntryDate { get; set; }
        public bool? ImmediateEntry { get; set; }
        public string? FreeSearch { get; set; }
    }
}
