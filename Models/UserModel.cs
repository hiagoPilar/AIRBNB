using AIRBNB.Enum;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace AIRBNB.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = null;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = null;

        [Required]
        [MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; } = null;

        [Required]
        public string PasswordHash { get; set; } = null;

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
        public ICollection<ReservationModel> Reservations { get; set; } = new List<ReservationModel>();
        public ICollection<MessageModel> SentMessages { get; set; } = new HashSet<MessageModel>();
        public ICollection<MessageModel> ReceivedMessages { get; set; } = new HashSet<MessageModel>();
        
        
    }
}
