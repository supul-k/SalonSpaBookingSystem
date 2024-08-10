using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.Models
{
    public class ServiceSalonSpaModel
    {
        [Key]
        [Column("ServiceSalonSpaId", TypeName = "nvarchar(450)")]
        public string ServiceSalonSpaId { get; set; }

        [Required]
        [Column("ServiceId", TypeName = "nvarchar(450)")]
        public string ServiceId { get; set; } // Foreign key

        [Required]
        [Column("SalonSpaId", TypeName = "nvarchar(450)")]
        public string SalonSpaId { get; set; } // Foreign key

        [Required]
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("ServiceId")]
        public virtual ServiceModel Service { get; set; }

        [ForeignKey("SalonSpaId")]
        public virtual SalonSpaModel SalonSpa { get; set; }
    }
}
