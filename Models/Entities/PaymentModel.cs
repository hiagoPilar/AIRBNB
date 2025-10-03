using AIRBNB.Enum;
using System.ComponentModel.DataAnnotations;

namespace AIRBNB.Models.Entities
{
    public class PaymentModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ReservationId { get; set; }
        public ReservationModel? Reservation { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; } //payment amount

        [Required]
        public PaymentMethod Method { get; set; }

        [Required]
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? PaidAt { get; set; } //when it was actually paid

    }
}
