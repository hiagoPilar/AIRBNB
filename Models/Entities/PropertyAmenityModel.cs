using System.ComponentModel.DataAnnotations;

namespace AIRBNB.Models.Entities
{
    public class PropertyAmenityModel
    {

        //composite key will be set in the DataBaseContext via FLuentAPI
        
        public int PropertyId { get; set; }
        public PropertyModel? Property { get; set; }
        
        public int AmenityId { get; set; }
        public AmenityModel? Amenity { get; set; }
    }
}
