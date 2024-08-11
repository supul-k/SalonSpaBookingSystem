using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.DTO;

namespace SalonSpaBookingSystem.Interfaces.IServices
{
    public interface IAuthService
    {
        public Task<GeneralResponseInternalDTO> RegisterUserWithRoleAsync(UserRegisterRequestDTO registerRequest);

        public Task<GeneralResponseInternalDTO> UserExist(string Email);

        public Task<GeneralResponseInternalDTO> RoleExist(string Role);
    }
}
