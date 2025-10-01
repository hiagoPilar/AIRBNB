using AIRBNB.Enum;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AIRBNB.Models
{
    public class ReservationModel
    {
        [Key]
        public int Id { get; set; }

        public int PropertyId { get; set; }

        public int GuestId { get; set; }

        public DateTime Checkin {  get; set; } = DateTime.Now;

        [Required]
        public DateTime Checkout { get; set; }

        public decimal TotalPrice { get; set; }

        [Required]
        public StatusReservation Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        
    }
}
