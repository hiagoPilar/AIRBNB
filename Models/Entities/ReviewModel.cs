using System.ComponentModel.DataAnnotations;

namespace AIRBNB.Models.Entities
{
    public class ReviewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }
        public PropertyModel? Property {  get; set; }

        [Required]
        public int GuestId { get; set; }
        public UserModel? User { get; set; }

        [Required]
        [Range(1,5)]
        public int Rating { get; set; } //review 1 to 5 stars

        [MaxLength(1000)]
        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }
}
