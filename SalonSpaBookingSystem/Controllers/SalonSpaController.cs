using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalonSpaBookingSystem.DTO;
using SalonSpaBookingSystem.Interfaces.IServices;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalonSpaController : ControllerBase
    {
        private readonly ISalonSpaService _salonSpaService;
        private readonly IValidationService _validationService;

        public SalonSpaController(ISalonSpaService salonSpaService, IValidationService validationService)
        {
            _salonSpaService = salonSpaService;
            _validationService = validationService;
        }

        [Authorize(Policy = "RequireSalonOwnerRole")]
        [HttpPost("create-salonspa", Name = "CreateSalonSpa")]
        public async Task<IActionResult> CreateSalonSpa([FromBody] SalonSpaCreateRequestDTO request)
        {
            var validateEmail = await _validationService.ValidateEmail(request.Email);
            if (!validateEmail.Status)
            {
                return BadRequest(validateEmail);
            }

            var salonSpaExist = await _salonSpaService.SalonSpaExist(request.Email);
            if (salonSpaExist.Status)
            {
                return BadRequest(new { success = false, message = "Email already exists with a Salon|Spa" });
            }

            SalonSpaModel salonSpa = new SalonSpaModel();
            
            salonSpa.SalonSpaId = Guid.NewGuid().ToString();
            salonSpa.SalonOwnerId = request.SalonOwnerId;
            salonSpa.Email = request.Email;
            salonSpa.Name = request.Name;
            salonSpa.Description = request.Description;
            salonSpa.Address = request.Address;
            salonSpa.City = request.City;
            salonSpa.State = request.State;
            salonSpa.ZipCode = request.ZipCode;
            salonSpa.Country = request.Country;
            salonSpa.PhoneNumber = request.PhoneNumber;
            salonSpa.CreatedAt = DateTime.UtcNow;
            salonSpa.UpdatedAt = DateTime.UtcNow;

            var result = await _salonSpaService.CreateSalonSpa(salonSpa);
            if (!result.Status)
            {
                return BadRequest(result);
            }

            return Created(string.Empty, result);
        }
    }
}
