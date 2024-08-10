using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.Models
{
    public class ServiceModel
    {
        [Key]
        [Column("ServiceId", TypeName = "nvarchar(450)")]
        public string ServiceId { get; set; }

        [Required]
        [Column("Name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column("Description", TypeName = "nvarchar(500)")]
        public string Description { get; set; }

        [Required]
        [Column("Duration")]
        public int Duration { get; set; } // Duration in minutes

        [Required]
        [Column("Price", TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        // Navigation property
        public virtual ICollection<ServiceSalonSpaModel> ServiceSalonSpas { get; set; }
        public virtual ICollection<BookingModel> Bookings { get; set; }
    }
}
