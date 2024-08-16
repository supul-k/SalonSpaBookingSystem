using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Interfaces.IRepositories
{
    public interface IAvailabilityRepository
    {
        public Task<GeneralResponseInternalDTO> CreateAvailability(AvailabilityModel availability);

        public Task<GeneralResponseInternalDTO> CheckAvailability(string salonSpaId, DateOnly date);

        public Task<GeneralResponseInternalDTO> CheckTimeAvailability(string salonSpaId, DateOnly date, TimeSpan startTime, TimeSpan endTime);

        public Task<GeneralResponseInternalDTO> FetchAvailabilitiesBySalonSpaId(string salonSpaId);
    }
}
