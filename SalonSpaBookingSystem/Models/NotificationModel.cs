using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.Models
{
    public class NotificationModel
    {
        [Key]
        [Column("NotificationId", TypeName = "nvarchar(450)")]
        public string NotificationId { get; set; }

        [Required]
        [Column("UserId", TypeName = "nvarchar(450)")]
        public string UserId { get; set; }

        [Required]
        [Column("Message", TypeName = "nvarchar(500)")]
        public string Message { get; set; }

        [Required]
        [Column("IsRead", TypeName = "bit")]
        public bool IsRead { get; set; }

        [Required]
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        // Navigation property
        public virtual UserModel User { get; set; }
    }
}
