using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.DTO
{
    public class ServiceUpdateRequestDTO
    {
        [Required]
        public string ServiceId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? Duration { get; set; }

        public decimal? Price { get; set; }
    }
}
