using AIRBNB.Enum;
using System.ComponentModel.DataAnnotations;

namespace AIRBNB.Models
{
    public class MessageModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SenderId { get; set; } //FK for who send the message
        public UserModel? Sender { get; set; }

        [Required]
        public int ReceiverId { get; set; } // FK for who received the message
        public UserModel? Receiver { get; set; }

        
        public int? PropertyId { get; set; } //FK optional for property
        public PropertyModel? Property { get; set; }

        
        public int? ReservationId { get; set; }
        public ReservationModel? Reservation { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Content { get; set; } = null;

        [Required]
        public MessageStatus Status { get; set; } = MessageStatus.Sent;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
