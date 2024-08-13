using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalonSpaBookingSystem.DTO;
using SalonSpaBookingSystem.DTO.InternalDTO;
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

        [Authorize(Policy = "RequireAdminOrSalonOwnerRole")]
        [HttpPost("create-salonspa", Name = "CreateSalonSpa")]
        public async Task<IActionResult> CreateSalonSpa([FromBody] SalonSpaCreateRequestDTO request)
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }

        [Authorize(Policy = "RequireAdminOrSalonOwnerRole")]
        [HttpPut("update-salonspa", Name = "UpdateSalonSpa")]
        public async Task<IActionResult> UpdateSalonSpa([FromBody] SalonSpaUpdateRequestDTO request)
        {
            try
            {
                var salonSpaResult = await _salonSpaService.FindSalonSpa(request.SalonSpaId);
                if (!salonSpaResult.Status)
                {
                    return BadRequest(salonSpaResult);
                }

                SalonSpaModel salonSpa = salonSpaResult.Data as SalonSpaModel;
                if (salonSpa == null)
                {
                    return BadRequest(new GeneralResponseInternalDTO(false, "Error processing Salon Spa data."));
                }

                if (!string.IsNullOrEmpty(request.Name)) salonSpa.Name = request.Name;
                if (!string.IsNullOrEmpty(request.Description)) salonSpa.Description = request.Description;
                if (!string.IsNullOrEmpty(request.Address)) salonSpa.Address = request.Address;
                if (!string.IsNullOrEmpty(request.City)) salonSpa.City = request.City;
                if (!string.IsNullOrEmpty(request.State)) salonSpa.State = request.State;
                if (!string.IsNullOrEmpty(request.ZipCode)) salonSpa.ZipCode = request.ZipCode;
                if (!string.IsNullOrEmpty(request.Country)) salonSpa.Country = request.Country;
                if (!string.IsNullOrEmpty(request.PhoneNumber)) salonSpa.PhoneNumber = request.PhoneNumber;
                if (!string.IsNullOrEmpty(request.Email)) salonSpa.Email = request.Email;
                salonSpa.UpdatedAt = DateTime.UtcNow;

                var result = await _salonSpaService.UpdateSalonSpa(salonSpa);
                if (result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpDelete("delete-salonspa/{salonSpaId}", Name = "DeleteSalonSpa")]
        public async Task<IActionResult> DeleteSalonSpa(string salonSpaId)
        {
            try
            {
                var salonSpaResult = await _salonSpaService.FindSalonSpa(salonSpaId);
                if (!salonSpaResult.Status)
                {
                    return BadRequest(salonSpaResult);
                }

                var salonSpa = salonSpaResult.Data as SalonSpaModel;

                var result = await _salonSpaService.DeleteSalonSpa(salonSpa);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }

        [HttpGet("get-salonspas", Name = "GetSalonSpas")]
        public async Task<IActionResult> FetchAllSalonSpas()
        {
            try
            {
                var result = await _salonSpaService.FetchAllSalonSpas();
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }

        [HttpGet("get-salonspa/{salonSpaId}", Name = "GetSalonSpaById")]
        public async Task<IActionResult> FindSalonSpa(string salonSpaId)
        {
            try
            {
                var result = await _salonSpaService.FindSalonSpa(salonSpaId);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }
    }
}
