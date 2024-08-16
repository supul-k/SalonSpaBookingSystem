using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Interfaces.IServices
{
    public interface IAvailabilityService
    {
        public Task<GeneralResponseInternalDTO> CreateAvailability(AvailabilityModel availability);

        public Task<GeneralResponseInternalDTO> CheckAvailability(string salonSpaId, DateOnly date);

        public Task<GeneralResponseInternalDTO> FetchAvailabilitiesBySalonSpaId(string salonSpaId);

        public Task<GeneralResponseInternalDTO> CheckTimeAvailability(string salonSpaId, DateOnly date, TimeSpan startTime, TimeSpan endTime);
    }
}
