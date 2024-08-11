using SalonSpaBookingSystem.DTO;
using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Interfaces.IServices
{
    public interface IJWTService
    {
        public Task<GeneralResponseInternalDTO> GenerateJwtToken(UserResponseDTO userData);
    }
}
