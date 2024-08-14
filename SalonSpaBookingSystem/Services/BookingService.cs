using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Interfaces.IServices;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<GeneralResponseInternalDTO> CreateBooking(BookingModel booking)
        {
            try
            {
                var result = await _bookingRepository.CreateBooking(booking);
                return result;
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
                var result = await _bookingRepository.FindBooking(bookingId);
                return result;
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
                var result = await _bookingRepository.UpdateBooking(booking);
                return result;
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
                var result = await _bookingRepository.DeleteBooking(booking);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> FetchBookings()
        {
            try
            {
                var result = await _bookingRepository.FetchBookings();
                return result;
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
                var result = await _bookingRepository.FetchBookingsByUserId(userId);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
