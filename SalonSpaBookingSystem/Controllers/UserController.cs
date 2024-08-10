using SalonSpaBookingSystem.DTO;
using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Interfaces.IServices;
using SalonSpaBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace SalonSpaBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly IValidationService _validationService;
        //private readonly IUserService _userService;
        //private readonly IHashPasswordService _hashPasswordService;
        //private readonly IJWTService _jwtService;
        //private readonly IUserProfileService _userProfileService;

        //public UserController(
        //    IValidationService validationService,
        //    IUserService userService,
        //    IHashPasswordService hashPasswordService,
        //    IJWTService jWTService,
        //    IUserProfileService userProfileService
        //    ) 
        //{
        //    _validationService = validationService;
        //    _userService = userService;
        //    _hashPasswordService = hashPasswordService;
        //    _jwtService = jWTService;
        //    _userProfileService = userProfileService;
        //}

        //[HttpPost("create-user", Name = "CreateUser")]
        //public async Task<IActionResult> CreateUser(UserRegisterRequestDTO request)
        //{
        //    try
        //    {
        //        var passwordValidation = await _validationService.ValidatePassword(request.Password);
        //        if (!passwordValidation.Status)
        //        {
        //            return BadRequest(passwordValidation);
        //        }

        //        var emailValidation = await _validationService.ValidateEmail(request.Email);
        //        if (!emailValidation.Status)
        //        {
        //            return BadRequest(emailValidation);
        //        }

        //        var userExist = await _userService.UserExist(request.Email);
        //        if (userExist.Status)
        //        {
        //            var response = new GeneralResposnseDTO(userExist.Status, "Email already Exist!");
        //            return BadRequest(response);
        //        }

        //        var hashedPasswordResponse = await _hashPasswordService.HashPassword(request.Password);
        //        if (!hashedPasswordResponse.Status)
        //        {
        //            var response = new GeneralResposnseDTO(hashedPasswordResponse.Status, "Failed to hash password");
        //            return BadRequest(response);
        //        }

        //        var hashedPassword = hashedPasswordResponse.Message;

        //        UserModel user = new UserModel();

        //        user.Id = Guid.NewGuid().ToString();
        //        user.FirstName = request.FirstName;
        //        user.LastName = request.LastName;
        //        user.Email = request.Email;
        //        user.PasswordHash = hashedPassword;
        //        user.PhoneNumber = request.PhoneNumber;
        //        user.Role = request.Role;
        //        user.CreatedAt = DateTime.UtcNow;
        //        user.UpdatedAt = DateTime.UtcNow;

        //        var result = await _userService.CreateUser(user);
        //        if (!result.Status)
        //        {
        //            return BadRequest(result);
        //        }

        //        return Created( string.Empty, new GeneralResposnseDTO(true, result.Message));

        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralResposnseDTO rsponse = new GeneralResposnseDTO(false, ex.Message);
        //        return BadRequest(rsponse);
        //    }
        //}

        //[HttpPost("login-user", Name = "LoginUser")]
        //public async Task<IActionResult> LoginUser(UserLoginDTO request)
        //{
        //    try
        //    {
        //        var passwordValidation = await _validationService.ValidatePassword(request.Password);
        //        if (!passwordValidation.Status)
        //        {
        //            return BadRequest(passwordValidation);
        //        }

        //        var emailValidation = await _validationService.ValidateEmail(request.Email);
        //        if (!emailValidation.Status)
        //        {
        //            return BadRequest(emailValidation);
        //        }

        //        var existingUser = await _userService.UserExist(request.Email);
        //        if (!existingUser.Status)
        //        {
        //            var response = new GeneralResposnseDTO(existingUser.Status, existingUser.Message);
        //            return BadRequest(response);
        //        }

        //        if (existingUser?.Data is UserModel userData)
        //        {
        //            var authenticationResult = await _userService.AuthenticateUser(request.Password, userData.PasswordHash);
        //            if (authenticationResult.Status)
        //            {
        //                var JWTToken = await _jwtService.GenerateJwtToken(userData);
        //                if (JWTToken.Status)
        //                {
        //                    return Ok(new GeneralResponseInternalDTO(JWTToken.Status, JWTToken.Message, JWTToken.Data));
        //                }
        //                else
        //                {
        //                    return BadRequest(JWTToken);
        //                }
        //            }
        //            else
        //            {
        //                return BadRequest(authenticationResult);
        //            }
        //        }
        //        else
        //        {
        //            var response = new GeneralResposnseDTO(false, "Invalid User data format");
        //            return BadRequest(response);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralResposnseDTO response = new GeneralResposnseDTO(false, ex.Message);
        //        return BadRequest(response);
        //    }
        //}
    }
}
