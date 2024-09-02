using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.DTO
{
    public class ReviewUpdateRequestDTO
    {
        [Range(1, 5)]
        public int? Rating { get; set; }

        public string? Comment { get; set; }
    }
}
