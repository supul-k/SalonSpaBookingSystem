using SalonSpaBookingSystem.DatabaseAccess;
using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace SalonSpaBookingSystem.Repositories
{
    //public class UserRepository : IUserRepository
    //{
    //    private readonly ApplicationDbContext _context;

    //    public UserRepository(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }
    //    public async Task<GeneralResponseInternalDTO> UserExist(string Email)
    //    {
    //        try
    //        {
    //            var existingUser =  await _context.Users.FirstOrDefaultAsync(u => u.Email == Email);
    //            if (existingUser == null)
    //            {
    //                return new GeneralResponseInternalDTO(false, "User does not exist");
    //            }

    //            return new GeneralResponseInternalDTO(true, "User already exists", existingUser);                

    //        }
    //        catch (Exception ex)
    //        {
    //            return  new GeneralResponseInternalDTO(false, ex.Message);
    //        }
    //    }

    //    public async Task<GeneralResponseInternalDTO> CreateUser(UserModel user)
    //    {
    //        try
    //        {
    //            _context.Users.Add(user);
    //            await _context.SaveChangesAsync();

    //            return new GeneralResponseInternalDTO(true, "User created successfully");                
    //        }
    //        catch (Exception ex)
    //        {
    //            return new GeneralResponseInternalDTO(false, ex.Message);
    //        }
    //    }
    //}
}
