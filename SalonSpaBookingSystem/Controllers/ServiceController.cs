using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SalonSpaBookingSystem.DTO;
using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IServices;
using SalonSpaBookingSystem.Models;
using SalonSpaBookingSystem.Services;

namespace SalonSpaBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [Authorize(Policy = "RequireAdminOrSalonOwnerRole")]
        [HttpPost("create-service", Name = "CreateService")]
        public async Task<IActionResult> CreateService([FromBody] ServiceCreateRequestDTO request)
        {
            try
            {
                var serviceNameExist = await _serviceService.FetchServiceByName(request.Name);
                if (serviceNameExist.Status)
                {
                    return BadRequest(new GeneralResposnseDTO(false, "Service name already exist"));
                }

                ServiceModel service = new ServiceModel();
                service.ServiceId = Guid.NewGuid().ToString();
                service.Name = request.Name;
                service.Description = request.Description;
                service.Duration = request.Duration;
                service.Price = request.Price;
                service.CreatedAt = DateTime.UtcNow;
                service.UpdatedAt = DateTime.UtcNow;

                var result = await _serviceService.CreateService(service);
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
        [HttpPut("update-service", Name = "UpdateService")]
        public async Task<IActionResult> UpdateService([FromBody] ServiceUpdateRequestDTO request)
        {
            try
            {
                var serviceResult = await _serviceService.FetchServiceById(request.ServiceId);
                if (!serviceResult.Status)
                {
                    return BadRequest(serviceResult);
                }

                ServiceModel service = serviceResult.Data as ServiceModel;
                if (!string.IsNullOrEmpty(request.Name)) service.Name = request.Name;
                if (!string.IsNullOrEmpty(request.Description)) service.Description = request.Description;
                if (request.Duration.HasValue) service.Duration = request.Duration.Value;
                if (request.Price.HasValue) service.Price = request.Price.Value;
                service.UpdatedAt = DateTime.UtcNow;

                var result = await _serviceService.UpdateService(service);
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

        [Authorize(Policy = "RequireAdminRole")]
        [HttpDelete("delete-service/{serviceId}", Name = "DeleteService")]
        public async Task<IActionResult> DeleteService(string serviceId)
        {
            try
            {
                var serviceResult = await _serviceService.FetchServiceById(serviceId);
                if (!serviceResult.Status)
                {
                    return BadRequest(serviceResult);
                }

                var service = serviceResult.Data as ServiceModel;

                var result = await _serviceService.DeleteService(service);
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

        [HttpGet("get-services", Name = "GetServices")]
        public async Task<IActionResult> FetchServices()
        {
            try
            {
                var result = await _serviceService.FetchServices();
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

        [HttpGet("get-service/{serviceId}", Name = "GetServiceById")]
        public async Task<IActionResult> FetchServiceById(string serviceId)
        {
            try
            {
                var result = await _serviceService.FetchServiceById(serviceId);
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
