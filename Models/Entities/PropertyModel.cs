using AIRBNB.Enum;
using System.ComponentModel.DataAnnotations;

namespace AIRBNB.Models.Entities
{
    public class PropertyModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int HostId { get; set; }
        public UserModel? Host { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        [MaxLength(300)]
        public string Location { get; set; } = string.Empty;

        [Required]
        public decimal PricePerNight { get; set; }

        [Required]
        public PropertyType PropertyType { get; set; }

        public PoolModel? Pool { get; set; }
        public GarageModel? Garage { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        //Relations
        public ICollection<ReservationModel> Reservations {  get; set; } = new List<ReservationModel>();
        public ICollection<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();
        public ICollection<PhotoModel> Photos { get; set; } = new List<PhotoModel>();

        public ICollection<FavoriteModel> Favorites { get; set; } = new HashSet<FavoriteModel>();

        public ICollection<MessageModel> Messages { get; set; } = new HashSet<MessageModel>();

    }
}
