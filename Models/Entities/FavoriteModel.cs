using System.ComponentModel.DataAnnotations;

namespace AIRBNB.Models.Entities
{
    public class FavoriteModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int GuestId { get; set; }
        public UserModel? User { get; set; }

        [Required]
        public int PropertyId { get; set; }
        public PropertyModel? Property { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }
}
