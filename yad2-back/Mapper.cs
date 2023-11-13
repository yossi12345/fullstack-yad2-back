using System.ComponentModel.DataAnnotations;
using System.Reflection;
using yad2_back.Models;

namespace yad2_back
{
    public class Mapper
    {
        public static UserDTOModel UserDAOToDTO(UserModel user, string? token=null)
        {
            UserDTOModel result=new()
            {
                Token = token,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.PhoneNumber,
                Mail = user.Email,
            };
            if (user.FavoriteApartments != null)
                result.FavoriteApartments = user.FavoriteApartments;
            if (user.LastApartmentSearches != null)
                result.LastApartmentSearches = user.LastApartmentSearches;
            if (user.ApartmentForSelling!=null)
                result.ApartmentForSelling = user.ApartmentForSelling;
            return result;
        }
        public static ApartmentDTOModel ApartmentDAOToDTO(ApartmentModel apartment) 
        {
            return new ApartmentDTOModel()
            {
                Id =apartment.Id,
                ImagesPaths=apartment.ImagesPaths,
                StreetNumber=apartment.StreetNumber,
                Street=apartment.Street,
                City=apartment.City, 
                Price=apartment.Price,
                AmountOfRooms=apartment.AmountOfRooms,
                AmountOfShowerRooms=apartment.AmountOfShowerRooms,
                Type =apartment.Type,
                Description=apartment.Description,
                Condition=apartment.Condition,
                View =apartment.View,
                isRearAsset=apartment.isRearAsset,
                Floor=apartment.Floor,
                AmountOfFloorsInBuilding =apartment.AmountOfFloorsInBuilding,
                AmountOfParkingPlaces=apartment.AmountOfParkingPlaces,
                AmountOfBalcony=apartment.AmountOfBalcony,
                Features=apartment.Features, 
                builtArea= apartment.builtArea,
                Area =apartment.Area,
                EntryDate=apartment.EntryDate,
                IsEntryDateFlexible =apartment.IsEntryDateFlexible,
                Phones=apartment.Phones,
                AdType =apartment.AdType,
                IsFrozen=apartment.IsFrozen,
                Advertiser=UserDAOToDTO(apartment.Advertiser)
             };
        }
        
    }
}
