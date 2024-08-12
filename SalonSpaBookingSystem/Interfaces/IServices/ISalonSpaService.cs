using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Interfaces.IServices
{
    public interface ISalonSpaService
    {
        public Task<GeneralResponseInternalDTO> CreateSalonSpa(SalonSpaModel salonSpa);

        public Task<GeneralResponseInternalDTO> SalonSpaExist(string Email);
    }
}
