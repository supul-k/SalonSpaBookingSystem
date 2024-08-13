using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Interfaces.IServices
{
    public interface IServiceService
    {
        public Task<GeneralResponseInternalDTO> CreateService(ServiceModel service);

        public Task<GeneralResponseInternalDTO> FetchServiceById(string serviceId);

        public Task<GeneralResponseInternalDTO> FetchServiceByName(string name);

        public Task<GeneralResponseInternalDTO> UpdateService(ServiceModel service);

        public Task<GeneralResponseInternalDTO> DeleteService(ServiceModel service);

        public Task<GeneralResponseInternalDTO> FetchServices();
    }
}
