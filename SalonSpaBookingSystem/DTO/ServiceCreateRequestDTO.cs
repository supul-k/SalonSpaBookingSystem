using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.DTO
{
    public class ServiceCreateRequestDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
