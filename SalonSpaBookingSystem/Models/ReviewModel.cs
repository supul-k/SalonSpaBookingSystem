using static SalonSpaBookingSystem.Models.SalonSpaModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.Models
{
    public class ReviewModel
    {
        [Key]
        [Column("ReviewId", TypeName = "nvarchar(450)")]
        public string ReviewId { get; set; }

        [Required]
        [Column("UserId", TypeName = "nvarchar(450)")]
        public string UserId { get; set; }

        [Required]
        [Column("SalonSpaId", TypeName = "nvarchar(450)")]
        public string SalonSpaId { get; set; }

        [Required]
        [Range(1, 5)]
        [Column("Rating")]
        public int Rating { get; set; }

        [Column("Comment", TypeName = "nvarchar(500)")]
        public string Comment { get; set; }

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
    }
}
