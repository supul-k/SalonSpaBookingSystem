using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.Models
{
    public class PaymentModel
    {
        [Key]
        [Column("PaymentId", TypeName = "nvarchar(450)")]
        public string PaymentId { get; set; }

        [Required]
        [Column("BookingId", TypeName = "nvarchar(450)")]
        public string BookingId { get; set; }

        [Required]
        [Column("Amount", TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [Column("PaymentDate")]
        public DateTime PaymentDate { get; set; }

        [Required]
        [Column("PaymentStatus", TypeName = "nvarchar(36)")]
        public int PaymentStatus { get; set; } 

        [Required]
        [Column("PaymentMethod", TypeName = "nvarchar(50)")]
        public string PaymentMethod { get; set; } 

        [Required]
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        // Navigation property

        [ForeignKey("BookingId")]
        public virtual BookingModel Booking { get; set; }
    }
}
