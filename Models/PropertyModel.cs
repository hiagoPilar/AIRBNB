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
        public string Location { get; set; }

        [Required]
        public decimal PricePerNight { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        //Relations
    }
}
