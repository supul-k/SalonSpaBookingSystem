using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.DTO;

namespace SalonSpaBookingSystem.Interfaces.IServices
{
    public interface IAuthService
    {
        public Task<GeneralResponseInternalDTO> RegisterUserWithRoleAsync(UserRegisterRequestDTO registerRequest);

        public Task<GeneralResponseInternalDTO> FindUser(string userId);

        public Task<GeneralResponseInternalDTO> UserExist(string Email);

        public Task<GeneralResponseInternalDTO> RoleExist(string Role);

        public Task<GeneralResponseInternalDTO> SignInAsync(UserSignInRequestDTO userSignInRequest, string UserName);

        public Task<GeneralResponseInternalDTO> GenerateJwtToken(UserResponseDTO userData);
    }
}
