using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.DTO
{
    public class BookingUpdateRequestDTO
    {
        [Required]
        public string BookingId { get; set; }

        public DateTime? BookingDate { get; set; }

        public DateTime? BookingTime { get; set; }

        public decimal? TotalPrice { get; set; }

        public string? Status { get; set; }
    }
}
