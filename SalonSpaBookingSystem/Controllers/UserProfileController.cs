using SalonSpaBookingSystem.DTO;
using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using SalonSpaBookingSystem.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace SalonSpaBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet("profile", Name = "GetUserProfileByUserID")]
        public async Task<IActionResult> GetUserProfileByUserId()
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized(new GeneralResposnseDTO(false, "User not authenticated"));
                }

                var userProfile = await _userProfileService.GetUserProfileByUserId(userId);
                if (userProfile.Status)
                {
                    return Ok(userProfile);
                }

                return NotFound(userProfile);
            }
            catch (Exception ex)
            {
                var response = new GeneralResposnseDTO(false, ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPut("update-profile", Name = "UpdateUserProfile")]
        public async Task<IActionResult> UpdateUserProfile(UserProfileUpdateRequestDTO request)
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized(new GeneralResposnseDTO(false, "User not authenticated"));
                }

                var userProfileResult = await _userProfileService.UserProfileExist(userId);                
                UserProfileModel userProfile;
                GeneralResponseInternalDTO result;

                if (!userProfileResult.Status)
                {
                    // UserProfile does not exist, create a new one
                    userProfile = new UserProfileModel
                    {
                        UserProfileId = Guid.NewGuid().ToString(),
                        UserId = userId,
                        Address = request.Address,
                        City = request.City,
                        State = request.State,
                        ZipCode = request.ZipCode,
                        Country = request.Country,
                        ProfilePictureUrl = request.ProfilePictureUrl,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    result = await _userProfileService.CreateUserProfile(userProfile);
                    if (!result.Status)
                    {
                        return BadRequest(result);
                    }
                }
                else
                {
                    // UserProfile exists, update it
                    userProfile = userProfileResult.Data as UserProfileModel;

                    if (!string.IsNullOrEmpty(request.Address)) userProfile.Address = request.Address;
                    if (!string.IsNullOrEmpty(request.City)) userProfile.City = request.City;
                    if (!string.IsNullOrEmpty(request.State)) userProfile.State = request.State;
                    if (!string.IsNullOrEmpty(request.ZipCode)) userProfile.ZipCode = request.ZipCode;
                    if (!string.IsNullOrEmpty(request.Country)) userProfile.Country = request.Country;
                    if (!string.IsNullOrEmpty(request.ProfilePictureUrl)) userProfile.ProfilePictureUrl = request.ProfilePictureUrl;

                    userProfile.UpdatedAt = DateTime.UtcNow;  // Update only once

                    result = await _userProfileService.UpdateUserProfile(userProfile);
                    if (!result.Status)
                    {
                        return BadRequest(result);
                    }
                }              

                return Ok(result);
            }
            catch (Exception ex)
            {
                var response = new GeneralResposnseDTO(false, ex.Message);
                return BadRequest(response);
            }
        }
    }
}
