using AIRBNB.Enum;
using System.ComponentModel.DataAnnotations;

namespace AIRBNB.Models
{
    public class PropertyModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int HostId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = null;

        public string? Description { get; set; }

        [Required]
        [MaxLength(300)]
        public string Location { get; set; } = null;

        [Required]
        public decimal PricePerNight { get; set; }

        [Required]
        public PropertyType PropertyType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        //Relations
    }
}
