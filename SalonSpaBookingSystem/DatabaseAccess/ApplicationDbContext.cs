using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.DatabaseAccess
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserProfileModel> UserProfiles { get; set; }
        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<SalonSpaModel> SalonSpas { get; set; }
        public DbSet<ServiceSalonSpaModel> ServiceSalonSpas { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<AvailabilityModel> Availabilities { get; set; }
        public DbSet<ReviewModel> Reviews { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }
        public DbSet<NotificationModel> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User and UserProfile (allow cascading delete)
            modelBuilder.Entity<UserProfileModel>()
                .HasOne(up => up.User)
                .WithOne(u => u.UserProfile)
                .HasForeignKey<UserProfileModel>(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User and Bookings (restrict cascading delete)
            modelBuilder.Entity<BookingModel>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // User and Reviews (restrict cascading delete)
            modelBuilder.Entity<ReviewModel>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // User and Notifications (restrict cascading delete)
            modelBuilder.Entity<NotificationModel>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // SalonSpa and Services (through ServiceSalonSpa)
            modelBuilder.Entity<ServiceSalonSpaModel>()
                .HasOne(ss => ss.SalonSpa)
                .WithMany(s => s.ServiceSalonSpas)
                .HasForeignKey(ss => ss.SalonSpaId);

            modelBuilder.Entity<ServiceSalonSpaModel>()
                .HasOne(ss => ss.Service)
                .WithMany(s => s.ServiceSalonSpas)
                .HasForeignKey(ss => ss.ServiceId);

            // SalonSpa and Bookings (restrict cascading delete)
            modelBuilder.Entity<BookingModel>()
                .HasOne(b => b.SalonSpa)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.SalonSpaId)
                .OnDelete(DeleteBehavior.Restrict);

            // SalonSpa and Reviews (restrict cascading delete)
            modelBuilder.Entity<ReviewModel>()
                .HasOne(r => r.SalonSpa)
                .WithMany(s => s.Reviews)
                .HasForeignKey(r => r.SalonSpaId)
                .OnDelete(DeleteBehavior.Cascade);

            // SalonSpa and Availabilities
            modelBuilder.Entity<AvailabilityModel>()
                .HasOne(a => a.SalonSpa)
                .WithMany(s => s.Availabilities)
                .HasForeignKey(a => a.SalonSpaId);

            // Service and SalonSpas (through ServiceSalonSpa)
            modelBuilder.Entity<ServiceSalonSpaModel>()
                .HasOne(ss => ss.Service)
                .WithMany(s => s.ServiceSalonSpas)
                .HasForeignKey(ss => ss.ServiceId);

            // Booking, Service, and SalonSpa
            modelBuilder.Entity<BookingModel>()
                .HasOne(b => b.Service)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Booking and Payment (allow cascading delete)
            modelBuilder.Entity<PaymentModel>()
                .HasOne(p => p.Booking)
                .WithOne(b => b.Payment)
                .HasForeignKey<PaymentModel>(p => p.BookingId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
