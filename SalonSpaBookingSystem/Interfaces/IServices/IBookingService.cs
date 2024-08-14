using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Interfaces.IServices
{
    public interface IBookingService
    {
        public Task<GeneralResponseInternalDTO> CreateBooking(BookingModel booking);

        public Task<GeneralResponseInternalDTO> FindBooking(string bookingId);

        public Task<GeneralResponseInternalDTO> UpdateBooking(BookingModel booking);

        public Task<GeneralResponseInternalDTO> DeleteBooking(BookingModel booking);

        public Task<GeneralResponseInternalDTO> FetchBookings();

        public Task<GeneralResponseInternalDTO> FetchBookingsByUserId(string userId);
    }
}
