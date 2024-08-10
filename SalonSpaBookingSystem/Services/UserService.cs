using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Interfaces.IServices;
using SalonSpaBookingSystem.Models;

namespace BookingSystem.Services
{
    //public class UserService : IUserService
    //{
    //    private readonly IUserRepository _userRepository;
    //    private readonly IHashPasswordService _hashPasswordService;

    //    public UserService(IUserRepository userRepository, IHashPasswordService hashPasswordService)
    //    {
    //        _userRepository = userRepository;
    //        _hashPasswordService = hashPasswordService;
    //    }

    //    public async Task<GeneralResponseInternalDTO> UserExist(string Email)
    //    {
    //        try
    //        {
    //            var result = await _userRepository.UserExist(Email);
    //            return result;
    //        }
    //        catch (Exception ex)
    //        {
    //            var response = new GeneralResponseInternalDTO(false, ex.Message);
    //            return response;
    //        }
    //    }

    //    public async Task<GeneralResponseInternalDTO> CreateUser(UserModel user)
    //    {
    //        try
    //        {
    //            var result = await _userRepository.CreateUser(user);
    //            return result;
    //        }
    //        catch (Exception ex)
    //        {
    //            var response = new GeneralResponseInternalDTO(false, ex.Message);
    //            return response;
    //        }
    //    }

    //    public async Task<GeneralResponseInternalDTO> AuthenticateUser(string reqPassword, string hashedPassword)
    //    {
    //        try
    //        {
    //            var result = await _hashPasswordService.VerifyPassword(reqPassword, hashedPassword);
    //            return result;
    //        }
    //        catch (Exception ex)
    //        {
    //            var response = new GeneralResponseInternalDTO(false, ex.Message);
    //            return response;
    //        }
    //    }
    //}
}
