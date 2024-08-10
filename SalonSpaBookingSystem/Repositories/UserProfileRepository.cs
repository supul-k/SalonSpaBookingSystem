using SalonSpaBookingSystem.DatabaseAccess;
using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace SalonSpaBookingSystem.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponseInternalDTO> CreateUserProfile(UserProfileModel profile)
        {
            try
            {
                await _context.UserProfiles.AddAsync(profile);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "User Profile Created Successfully");
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
                var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(up => up.UserId == userId);
                if (userProfile == null)
                {
                    return new GeneralResponseInternalDTO(true, "User Profile does not exist");
                }

                return new GeneralResponseInternalDTO(true, "User Profile found", userProfile);                

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
                _context.UserProfiles.Update(userProfile);
                await _context.SaveChangesAsync();

                var response = new GeneralResponseInternalDTO(true, "User Profile Updated Successfully");
                return response;
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
                var existingUserProfile = await _context.UserProfiles.FirstOrDefaultAsync(up =>up.UserId == userId);
                if (existingUserProfile == null)
                {
                    return new GeneralResponseInternalDTO(false, "User Profile does not exist");                    
                }

                return new GeneralResponseInternalDTO(true, "User Profile Exist", existingUserProfile);
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
