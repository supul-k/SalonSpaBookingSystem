using Microsoft.AspNetCore.Mvc;
using SalonSpaBookingSystem.DTO;
using SalonSpaBookingSystem.Interfaces.IServices;

namespace SalonSpaBookingSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]    
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register", Name = "RegisterUser")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestDTO request)
        {
            try
            {
                var roleExist = await _authService.RoleExist(request.Role);
                if (!roleExist.Status)
                {
                    return BadRequest(roleExist);
                }

                var result = await _authService.RegisterUserWithRoleAsync(request);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Created(string.Empty, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }

        [HttpPost("login", Name = "SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserSignInRequestDTO request)
        {
            try
            {
                var userData = await _authService.UserExist(request.Email);
                if (!userData.Status)
                {
                    return BadRequest(userData);
                }

                // Cast the data to UserResponseDTO
                var userResponseData = (UserResponseDTO)userData.Data;

                var result = await _authService.SignInAsync(request, userResponseData.UserName);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                var tokenResult = await _authService.GenerateJwtToken(userResponseData);
                if (!tokenResult.Status)
                {
                    return BadRequest(tokenResult);
                }

                return Ok(new
                {
                    Success = true,
                    result.Message,
                    Token = tokenResult.Message
                });
            }    
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }
    }
}
