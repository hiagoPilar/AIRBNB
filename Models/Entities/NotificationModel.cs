using AIRBNB.Enum;
using System.ComponentModel.DataAnnotations;

namespace AIRBNB.Models.Entities
{
    public class NotificationModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserID { get; set; } 
        public UserModel? User { get; set; }

        [Required]
        public NotificationType Type { get; set; }

        [Required]
        [MaxLength(300)]
        public string Message { get; set; } = string.Empty;

        public bool IsRead { get; set; } = false; //if it has already been read

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
