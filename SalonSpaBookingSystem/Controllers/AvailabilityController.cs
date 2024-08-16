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
    public class AvailabilityController : ControllerBase
    {
        private readonly IAvailabilityService _availabilityService;
        private readonly ISalonSpaService _salonSpaService;

        public AvailabilityController(IAvailabilityService availabilityService, ISalonSpaService salonSpaService)
        {
            _availabilityService = availabilityService;
            _salonSpaService = salonSpaService;
        }

        [HttpPost("create-availability/{salonSpaId}", Name = "CreateAvailabilityForSalonSpa")]
        public async Task<IActionResult> CreateAvailability(AvailabilityCreateRequestDTO request, string salonSpaId)
        {
            try
            {
                var salonSpaResult = await _salonSpaService.FindSalonSpa(salonSpaId);
                if (!salonSpaResult.Status)
                {
                    return BadRequest(salonSpaResult);
                }

                var availableSlot = await _availabilityService.CheckTimeAvailability(salonSpaId, request.Date, request.StartTime, request.EndTime);
                if (!availableSlot.Status)
                {
                    return BadRequest(availableSlot);
                }

                AvailabilityModel availability = new AvailabilityModel
                {
                    AvailabilityId = Guid.NewGuid().ToString(),
                    SalonSpaId = salonSpaId,
                    Date = request.Date,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                var result = await _availabilityService.CreateAvailability(availability);
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

        [HttpGet("get-availabilities/{salonSpaId}", Name = "FetchAvailabilitiesForSalonSpaForDate")]
        public async Task<IActionResult> FetchAvailabilities(string salonSpaId, [FromQuery] DateTime date)
        {
            try
            {
                var result = await _availabilityService.CheckAvailability(salonSpaId, date);
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
    }
}
