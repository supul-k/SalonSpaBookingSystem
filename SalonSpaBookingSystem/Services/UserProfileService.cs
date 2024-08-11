using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Interfaces.IServices;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<GeneralResponseInternalDTO> CreateUserProfile(UserProfileModel profile)
        {
            try
            {
                var result = await _userProfileRepository.CreateUserProfile(profile);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> GetUserProfileByUserId(string userId)
        {
            try
            {
                var result = await _userProfileRepository.GetUserProfileByUserId(userId);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> UpdateUserProfile(UserProfileModel userProfile)
        {
            try
            {
                var result = await _userProfileRepository.UpdateUserProfile(userProfile);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> UserProfileExist(string userId)
        {
            try
            {
                var result = await _userProfileRepository.UserProfileExist(userId);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
