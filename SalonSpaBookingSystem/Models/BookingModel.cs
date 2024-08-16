using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static SalonSpaBookingSystem.Models.SalonSpaModel;

namespace SalonSpaBookingSystem.Models
{
    public class BookingModel
    {
        [Key]
        [Column("BookingId", TypeName = "nvarchar(450)")]
        public string BookingId { get; set; }

        [Required]
        [Column("UserId", TypeName = "nvarchar(450)")]
        public string UserId { get; set; }

        [Required]
        [Column("SalonSpaId", TypeName = "nvarchar(450)")]
        public string SalonSpaId { get; set; }

        [Required]
        [Column("ServiceId", TypeName = "nvarchar(450)")]
        public string ServiceId { get; set; }

        [Required]
        [Column("BookingDate")]
        public DateOnly BookingDate { get; set; }

        [Required]
        [Column("BookingTime")]
        public TimeSpan BookingTime { get; set; }

        [Required]
        [Column("Status", TypeName = "nvarchar(50)")]
        public string Status { get; set; }

        [Required]
        [Column("TotalPrice", TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        // Navigation properties


        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }
        [ForeignKey("SalonSpaId")]
        public virtual SalonSpaModel SalonSpa { get; set; }
        [ForeignKey("ServiceId")]
        public virtual ServiceModel Service { get; set; }
        [ForeignKey("SalonSpaId")]

        //Booking has one payment
        public virtual PaymentModel Payment { get; set; }
    }
}
