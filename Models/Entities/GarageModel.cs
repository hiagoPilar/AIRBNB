using AIRBNB.Enum;
using System.ComponentModel.DataAnnotations;

namespace AIRBNB.Models.Entities
{
    public class GarageModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }
        public PropertyModel? Property { get; set; }

        [Required]
        public GarageType Type { get; set; }

        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }
    }
}
