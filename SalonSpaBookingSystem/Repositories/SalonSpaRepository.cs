using Microsoft.EntityFrameworkCore;
using SalonSpaBookingSystem.DatabaseAccess;
using SalonSpaBookingSystem.DTO;
using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Repositories
{
    public class SalonSpaRepository : ISalonSpaRepository
    {
        private readonly ApplicationDbContext _context;

        public SalonSpaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponseInternalDTO> CreateSalonSpa(SalonSpaModel salonSpa)
        {
            try
            {
                await _context.SalonSpas.AddAsync(salonSpa);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "Salon|Spa Created Successfully");
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> SalonSpaExist(string Email)
        {
            try
            {
                var result =  await _context.SalonSpas.FirstOrDefaultAsync(ss => ss.Email == Email);
                if (result == null)
                {
                    return new GeneralResponseInternalDTO(false, "Salon|Spa not found");
                }

                return new GeneralResponseInternalDTO(true, "Salon|Spa found with the attached Email", result);
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> FindSalonSpa(string SalonSpaId)
        {
            try
            {
                var result = await _context.SalonSpas.FindAsync(SalonSpaId);
                if (result == null)
                {
                    return new GeneralResponseInternalDTO(false, "Salon|Spa not found");
                }

                return new GeneralResponseInternalDTO(true, "Salon|Spa found", result);
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> UpdateSalonSpa(SalonSpaModel salonSpa)
        {
            try
            {
                _context.SalonSpas.Update(salonSpa);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "Salon|Spa updated successfully");
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> DeleteSalonSpa(SalonSpaModel salonSpa)
        {
            try
            {
                _context.SalonSpas.Remove(salonSpa);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "Salon|Spa deleted successfully");
            }
            catch(Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> FetchAllSalonSpas()
        {
            try
            {
                var result = await _context.SalonSpas.ToListAsync();
                if (!result.Any())
                {
                    return new GeneralResponseInternalDTO(false, "Salon|Spas not found");
                }

                return new GeneralResponseInternalDTO(true, "Salon|Spas found", result);
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
