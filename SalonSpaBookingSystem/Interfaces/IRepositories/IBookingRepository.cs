using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Interfaces.IRepositories
{
    public interface IBookingRepository
    {
        public Task<GeneralResponseInternalDTO> CreateBooking(BookingModel booking);

        public Task<GeneralResponseInternalDTO> FindBooking(string bookingId);

        public Task<GeneralResponseInternalDTO> UpdateBooking(BookingModel booking);

        public Task<GeneralResponseInternalDTO> DeleteBooking(BookingModel booking);

        public Task<GeneralResponseInternalDTO> FetchBookings();

        public Task<GeneralResponseInternalDTO> FetchBookingsByUserId(string userId);

        public Task<GeneralResponseInternalDTO> IsBookingTimeAvailable(string salonSpaId, DateOnly bookingDate, TimeSpan bookingTime);
    }
}
