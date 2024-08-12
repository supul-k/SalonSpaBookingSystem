using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Interfaces.IServices;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Services
{
    public class SalonSpaService : ISalonSpaService
    {
        private readonly ISalonSpaRepository _salonSpaRepository;

        public SalonSpaService(ISalonSpaRepository salonSpaRepository)
        {
            _salonSpaRepository = salonSpaRepository;
        }

        public async Task<GeneralResponseInternalDTO> CreateSalonSpa(SalonSpaModel salonSpa)
        {
            try
            {
                var result = await _salonSpaRepository.CreateSalonSpa(salonSpa);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> SalonSpaExist(string Email)
        {
            try
            {
                var result = await _salonSpaRepository.SalonSpaExist(Email);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
