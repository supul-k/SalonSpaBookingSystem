using SalonSpaBookingSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.DTO
{
    public class UserRegisterRequestDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
