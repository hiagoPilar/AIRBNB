using AIRBNB.Enum;

namespace AIRBNB.Models.DTOs.Properties
{
    public class PropertyResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public PropertyType PropertyType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
