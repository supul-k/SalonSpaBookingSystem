using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Interfaces.IRepositories
{
    public interface IServiceRepository
    {
        public Task<GeneralResponseInternalDTO> CreateService(ServiceModel service);

        public Task<GeneralResponseInternalDTO> ServiceExist(string serviceId);

        public Task<GeneralResponseInternalDTO> UpdateService(ServiceModel service);

        public Task<GeneralResponseInternalDTO> DeleteService(ServiceModel service);

        public Task<GeneralResponseInternalDTO> FetchServices();
    }
}
