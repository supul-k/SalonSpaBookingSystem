using Microsoft.EntityFrameworkCore;
using SalonSpaBookingSystem.DatabaseAccess;
using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Repositories
{
    public class AvailabilityRepository : IAvailabilityRepository
    {
        private readonly ApplicationDbContext _context;

        public AvailabilityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponseInternalDTO> CreateAvailability(AvailabilityModel availability)
        {
            try
            {
                await _context.Availabilities.AddAsync(availability);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "Availability record created successfully");
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> CheckAvailability(string salonSpaId,DateOnly date)
        {
            try
            {
                var result = await _context.Availabilities.FirstOrDefaultAsync(a => a.SalonSpaId == salonSpaId && a.Date == date);
                if (result == null)
                {
                    return new GeneralResponseInternalDTO(false, "Availability records not found");
                }

                return new GeneralResponseInternalDTO(true, "Availability records found", result);
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> CheckTimeAvailability(string salonSpaId, DateOnly date, TimeSpan startTime, TimeSpan endTime)
        {
            try
            {
                var result = await _context.Availabilities
                    .Where(a => a.SalonSpaId == salonSpaId && a.Date == date)
                    .Where(a => (a.StartTime < endTime && a.EndTime > startTime))
                    .FirstOrDefaultAsync();
                if (result != null)
                {
                    return new GeneralResponseInternalDTO(false, "Time slot overlaps with an existing availability");
                }

                return new GeneralResponseInternalDTO(true, "Time slot is available");
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> FetchAvailabilitiesBySalonSpaId(string salonSpaId)
        {
            try
            {
                var result = await _context.Availabilities.Where(a => a.SalonSpaId == salonSpaId).ToListAsync();
                if (result == null)
                {
                    return new GeneralResponseInternalDTO(false, "Availabilities not found for given Salon|Spa");
                }

                return new GeneralResponseInternalDTO(true, "Availabilities found for given Spa|Salon", result);
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
