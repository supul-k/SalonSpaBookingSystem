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
        private readonly IValidationService _validationService;

        public AuthController(IAuthService authService, IValidationService validationService)
        {
            _authService = authService;
            _validationService = validationService;
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

    }
}
