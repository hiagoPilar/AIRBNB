using AIRBNB.Enum;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace AIRBNB.Models.Entities
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(25)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public UserRole Role { get; set; }

        [MaxLength(500)]
        public string? Bio { get; set; }

        [MaxLength(500)]
        [Url]
        public string? ProfilePictureUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        //Relations
        public ICollection<NotificationModel> Notifications { get; set; } = new List<NotificationModel>();
        public ICollection<ReservationModel> Reservations { get; set; } = new HashSet<ReservationModel>();
        public ICollection<MessageModel> SentMessages { get; set; } = new HashSet<MessageModel>();
        public ICollection<MessageModel> ReceivedMessages { get; set; } = new HashSet<MessageModel>();
        public ICollection<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();
        public ICollection<PropertyModel> Properties { get; set; } = new List<PropertyModel>();
        public ICollection<FavoriteModel> Favorites { get; set; } = new List<FavoriteModel>();
    }
        
        
    
}
