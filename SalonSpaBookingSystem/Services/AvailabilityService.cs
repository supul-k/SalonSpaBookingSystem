using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Interfaces.IServices;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IAvailabilityRepository _availabilityRepository;

        public AvailabilityService(IAvailabilityRepository availabilityRepository)
        {
            _availabilityRepository = availabilityRepository;
        }

        public async Task<GeneralResponseInternalDTO> CreateAvailability(AvailabilityModel availability)
        {
            try
            {
                var result = await _availabilityRepository.CreateAvailability(availability);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> CheckAvailability(string salonSpaId, DateOnly date)
        {
            try
            {
                var result = await _availabilityRepository.CheckAvailability(salonSpaId, date);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> CheckTimeAvailability(string salonSpaId, DateOnly date, TimeSpan startTime, TimeSpan endTime)
        {
            try
            {
                var result = await _availabilityRepository.CheckTimeAvailability(salonSpaId, date, startTime, endTime);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> FetchAvailabilitiesBySalonSpaId(string salonSpaId)
        {
            try
            {
                var result = await _availabilityRepository.FetchAvailabilitiesBySalonSpaId(salonSpaId);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
