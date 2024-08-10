using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonSpaBookingSystem.Models
{
    public class UserProfileModel
    {
        [Key]
        [Column("UserProfileId", TypeName = "nvarchar(450)")]
        public string UserProfileId { get; set; }

        [Required]
        [Column("UserId", TypeName = "nvarchar(450)")]
        public string UserId { get; set; } // Foreign key

        [Column("Address", TypeName = "nvarchar(300)")]
        public string? Address { get; set; }

        [Column("City", TypeName = "nvarchar(100)")]
        public string? City { get; set; }

        [Column("State", TypeName = "nvarchar(100)")]
        public string? State { get; set; }

        [Column("ZipCode", TypeName = "nvarchar(20)")]
        public string? ZipCode { get; set; }

        [Column("Country", TypeName = "nvarchar(100)")]
        public string? Country { get; set; }

        [Column("ProfilePictureUrl", TypeName = "nvarchar(200)")]
        public string? ProfilePictureUrl { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation property
        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }

    }
}
