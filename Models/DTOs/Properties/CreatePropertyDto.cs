using AIRBNB.Enum;

namespace AIRBNB.Models.DTOs.Properties
{
    public class CreatePropertyDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } 
        public string Location {  get; set; } = string.Empty;
        public decimal PricePerNight { get; set; } 
        public PropertyType PropertyType {  get; set; }


    }
}
