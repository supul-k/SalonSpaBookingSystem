using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.Models
{
    public class SalonSpaModel
    {
        [Key]
        [Column("SalonSpaId", TypeName = "nvarchar(450)")]
        public string SalonSpaId { get; set; }

        [Column("SalonOwnerId", TypeName = "nvarchar(450)")]
        public string SalonOwnerId { get; set; } // Foreign key

        [Required]
        [Column("Name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column("Description", TypeName = "nvarchar(500)")]
        public string Description { get; set; }

        [Required]
        [Column("Address", TypeName = "nvarchar(300)")]
        public string Address { get; set; }

        [Required]
        [Column("City", TypeName = "nvarchar(100)")]
        public string City { get; set; }

        [Required]
        [Column("State", TypeName = "nvarchar(100)")]
        public string State { get; set; }

        [Required]
        [Column("ZipCode", TypeName = "nvarchar(20)")]
        public string ZipCode { get; set; }

        [Required]
        [Column("Country", TypeName = "nvarchar(100)")]
        public string Country { get; set; }

        [Required]
        [Phone]
        [Column("PhoneNumber", TypeName = "nvarchar(15)")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Column("Email", TypeName = "nvarchar(256)")]
        public string Email { get; set; }

        [Required]
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("SalonOwnerId")]
        public virtual UserModel User { get; set; }
        public virtual ICollection<ServiceSalonSpaModel> ServiceSalonSpas { get; set; }
        public virtual ICollection<BookingModel> Bookings { get; set; }
        public virtual ICollection<ReviewModel> Reviews { get; set; }
        public virtual ICollection<AvailabilityModel> Availabilities { get; set; }
    }
}
