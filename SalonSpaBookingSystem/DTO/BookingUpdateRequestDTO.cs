using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.DTO
{
    public class BookingUpdateRequestDTO
    {
        [Required]
        public string BookingId { get; set; }

        public DateOnly? BookingDate { get; set; }

        public TimeSpan? BookingTime { get; set; }

        public decimal? TotalPrice { get; set; }

        public string? Status { get; set; }
    }
}
