using AIRBNB.Enum;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AIRBNB.Models.Entities
{
    public class ReservationModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }
        public PropertyModel? Property { get; set; }

        [Required]
        public int GuestId { get; set; }
        public UserModel? Guest { get; set; }

        [Required]
        public DateTime Checkin {  get; set; } = DateTime.Now;

        [Required]
        public DateTime Checkout { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public StatusReservation Status { get; set; } = StatusReservation.Pending;

        public PaymentModel? Payment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        //relations
        public ICollection<MessageModel> Messages { get; set; } = new HashSet<MessageModel>();

        
    }
}
