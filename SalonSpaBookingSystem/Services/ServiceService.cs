using Microsoft.EntityFrameworkCore;
using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Interfaces.IServices;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<GeneralResponseInternalDTO> CreateService(ServiceModel service)
        {
            try
            {
                var result = await _serviceRepository.CreateService(service);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> FetchServiceById(string serviceId)
        {
            try
            {
                var result = await _serviceRepository.FetchServiceById(serviceId);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> FetchServiceByName(string name)
        {
            try
            {
                var result = await _serviceRepository.FetchServiceByName(name);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> UpdateService(ServiceModel service)
        {
            try
            {
                var result = await _serviceRepository.UpdateService(service);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> DeleteService(ServiceModel service)
        {
            try
            {
                var result = await _serviceRepository.DeleteService(service);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> FetchServices()
        {
            try
            {
                var result = await _serviceRepository.FetchServices();
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
