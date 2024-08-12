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
                    return new GeneralResponseInternalDTO(false, "Salon|Spa does not exist");
                }

                return new GeneralResponseInternalDTO(true, "Email already Exist with a Salon|Spa", result);
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
