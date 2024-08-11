using SalonSpaBookingSystem.DTO;
using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Interfaces.IRepositories
{
    public interface IAuthRepository
    {
        public Task<GeneralResponseInternalDTO> UserExist(string Email);

        public Task<GeneralResponseInternalDTO> CreateUserAsync(UserModel user, string Password);

        public Task<GeneralResponseInternalDTO> AssignRolesAsync(UserModel user, string Role);

        public Task<GeneralResponseInternalDTO> RoleExist(string Role);

        public Task<GeneralResponseInternalDTO> SignInAsync(UserSignInRequestDTO userSignInRequest, string UserName);
    }
}
