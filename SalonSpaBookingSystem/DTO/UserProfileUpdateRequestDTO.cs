using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.DTO
{
    public class UserProfileUpdateRequestDTO
    {
        [Required]
        public string UserId { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? ZipCode { get; set; }

        public string? Country { get; set; }

        public string? ProfilePictureUrl { get; set; }
    }
}
