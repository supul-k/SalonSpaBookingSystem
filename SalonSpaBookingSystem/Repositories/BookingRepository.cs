using Microsoft.EntityFrameworkCore;
using SalonSpaBookingSystem.DatabaseAccess;
using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponseInternalDTO> CreateBooking(BookingModel booking)
        {
            try
            {
                await _context.Bookings.AddAsync(booking);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "Booking Created Successfully");
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> FindBooking(string bookingId)
        {
            try
            {
                var result = await _context.Bookings.FindAsync(bookingId);
                if (result == null)
                {
                    return new GeneralResponseInternalDTO(false, "Booking not found");
                }

                return new GeneralResponseInternalDTO(true, "Booking found", result);
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> UpdateBooking(BookingModel booking)
        {
            try
            {
                _context.Bookings.Update(booking);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "Booking updated successfully");
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> DeleteBooking(BookingModel booking)
        {
            try
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "Booking deleted successfully");
            }
            catch(Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> FetchBookings()
        {
            try
            {
                var result = await _context.Bookings.ToListAsync();
                if (!result.Any())
                {
                    return new GeneralResponseInternalDTO(false, "Bookings not found");
                }
                return new GeneralResponseInternalDTO(true, "Bookings found", result);
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> FetchBookingsByUserId(string userId)
        {
            try
            {
                var result = await _context.Bookings
                    .Where(b => b.UserId == userId)
                    .ToListAsync();
                if (!result.Any())
                {
                    return new GeneralResponseInternalDTO(false, "Bookings not found");
                }

                return new GeneralResponseInternalDTO(true, "Bookings found for user", result);
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> IsBookingTimeAvailable(string salonSpaId, DateOnly bookingDate, TimeSpan bookingTime)
        {
            try
            {
                bool available = await _context.Bookings
                    .AnyAsync(b => b.SalonSpaId == salonSpaId &&
                                b.BookingDate == bookingDate &&
                                b.BookingTime == bookingTime);
                if (available)
                {
                    return new GeneralResponseInternalDTO(false, "The selected time slot is not available.");
                }

                return new GeneralResponseInternalDTO(true, "The time slot is available.");
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
