using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Interfaces.IRepositories
{
    public interface ISalonSpaRepository
    {
        public Task<GeneralResponseInternalDTO> CreateSalonSpa(SalonSpaModel salonSpa);

        public Task<GeneralResponseInternalDTO> SalonSpaExist(string Email);
    }
}
