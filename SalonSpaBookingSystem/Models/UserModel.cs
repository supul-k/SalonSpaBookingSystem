using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonSpaBookingSystem.Models
{
    public class UserModel : IdentityUser
    {

        [Column("FirstName", TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Column("LastName", TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        // Navigation property
        public virtual UserProfileModel UserProfile { get; set; }
        public virtual ICollection<BookingModel> Bookings { get; set; }
        public virtual ICollection<ReviewModel> Reviews { get; set; }
        public virtual ICollection<NotificationModel> Notifications { get; set; }
    }
}
