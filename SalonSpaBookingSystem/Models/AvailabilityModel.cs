using static SalonSpaBookingSystem.Models.SalonSpaModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.Models
{
    public class AvailabilityModel
    {
        [Key]
        [Column("AvailabilityId", TypeName = "nvarchar(450)")]
        public string AvailabilityId { get; set; }

        [Required]
        [Column("SalonSpaId", TypeName = "nvarchar(450)")]
        public string SalonSpaId { get; set; }

        [Required]
        [Column("Date")]
        public DateOnly Date { get; set; }

        [Required]
        [Column("StartTime")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [Column("EndTime")]
        public TimeSpan EndTime { get; set; }

        [Required]
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        // Navigation property

        [ForeignKey("SalonSpaId")]
        public virtual SalonSpaModel SalonSpa { get; set; }
    }
}
