using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Interfaces.IServices
{
    public interface ISalonSpaService
    {
        public Task<GeneralResponseInternalDTO> CreateSalonSpa(SalonSpaModel salonSpa);

        public Task<GeneralResponseInternalDTO> SalonSpaExist(string Email);

        public Task<GeneralResponseInternalDTO> FindSalonSpa(string SalonSpaId);

        public Task<GeneralResponseInternalDTO> UpdateSalonSpa(SalonSpaModel salonSpa);

        public Task<GeneralResponseInternalDTO> DeleteSalonSpa(SalonSpaModel salonSpa);

        public Task<GeneralResponseInternalDTO> FetchAllSalonSpas();
    }
}
