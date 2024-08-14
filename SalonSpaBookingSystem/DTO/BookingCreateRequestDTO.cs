using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.DTO
{
    public class BookingCreateRequestDTO
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string SalonSpaId { get; set; }

        [Required]
        public string ServiceId { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public DateTime BookingTime { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
