using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.DTO
{
    public class SalonSpaUpdateRequestDTO
    {
        [Required]
        public string SalonSpaId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? ZipCode { get; set; }


        public string? Country { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }
    }
}
