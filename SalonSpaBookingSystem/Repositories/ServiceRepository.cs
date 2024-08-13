using Microsoft.EntityFrameworkCore;
using SalonSpaBookingSystem.DatabaseAccess;
using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponseInternalDTO> CreateService(ServiceModel service)
        {
            try
            {
                await _context.Services.AddAsync(service);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "Service Created Successfully");
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> ServiceExist(string serviceId)
        {
            try
            {
                var result = await _context.Services.FindAsync(serviceId);
                if (result == null)
                {
                    return new GeneralResponseInternalDTO(false, "Service not found");
                }

                return new GeneralResponseInternalDTO(true, "Service found", result);
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
                _context.Services.Update(service);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "Service updated successfully");
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
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(false, "Service deleted successfully");
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
                var result = await _context.Services.ToListAsync();
                if (!result.Any())
                {
                    return new GeneralResponseInternalDTO(false, "Serivces not found");
                }

                return new GeneralResponseInternalDTO(true, "Services found", result);
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
