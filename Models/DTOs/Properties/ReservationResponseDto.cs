namespace AIRBNB.Models.DTOs.Properties
{
    public class ReservationResponseDto
    {
        public int Id { get; set; }
        public string GuestName { get; set; } = string.Empty;
        public DateTime Checkin {  get; set; }
        public DateTime Checkout { get; set; }
        public decimal TotalPrice { get; set; }
        public string PropertyTitle { get; set; } = string.Empty;
    }
}
