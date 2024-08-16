using SalonSpaBookingSystem.DatabaseAccess;
using SalonSpaBookingSystem.DTO;
using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Interfaces.IServices;
using SalonSpaBookingSystem.Models;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IAuthRepository _authRepository;
    private readonly IJWTService _jwtService;

    public AuthService(
        ApplicationDbContext dbContext,
        IAuthRepository authRepository,
        IJWTService jWTService
        )
    {
        _dbContext = dbContext;
        _authRepository = authRepository;
        _jwtService = jWTService;
    }

    public async Task<GeneralResponseInternalDTO> RegisterUserWithRoleAsync(UserRegisterRequestDTO registerRequest)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                // Create user
                var user = new UserModel
                {
                    FirstName = registerRequest.FirstName,
                    LastName = registerRequest.LastName,
                    UserName = registerRequest.UserName,
                    Email = registerRequest.Email,
                    PhoneNumber = registerRequest.PhoneNumber,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                //create User
                var result = await _authRepository.CreateUserAsync(user, registerRequest.Password);
                if (!result.Status)
                {
                    return result;
                }

                // Assign role
                var roleResult = await _authRepository.AssignRolesAsync(user, registerRequest.Role);
                if (!roleResult.Status)
                {
                    return result;
                }

                // Commit transaction
                await transaction.CommitAsync();

                return new GeneralResponseInternalDTO(true, "User Created Successfully");
            }
            catch (Exception ex)
            {
                // Rollback transaction
                await transaction.RollbackAsync();
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }

    public async Task<GeneralResponseInternalDTO> FindUser(string userId)
    {
        try
        {
            var result = await _authRepository.FindUser(userId);
            return result;
        }
        catch (Exception ex)
        {
            return new GeneralResponseInternalDTO(false, ex.Message);
        }
    }

    public async Task<GeneralResponseInternalDTO> UserExist(string Email)
    {
        try
        {
            var result = await _authRepository.UserExist(Email);
            return result;
        }
        catch (Exception ex)
        {
            return new GeneralResponseInternalDTO(false, ex.Message);
        }
    }

    public async Task<GeneralResponseInternalDTO> RoleExist(string Role)
    {
        try
        {
            var result = await _authRepository.RoleExist(Role);
            return result;
        }
        catch (Exception ex)
        {
            return new GeneralResponseInternalDTO(false, ex.Message);
        }
    }

    public async Task<GeneralResponseInternalDTO> SignInAsync(UserSignInRequestDTO userSignInRequest, string UserName)
    {
        try
        {
            var result = await _authRepository.SignInAsync(userSignInRequest, UserName);
            return result;
        }
        catch (Exception ex)
        {
            return new GeneralResponseInternalDTO(false, ex.Message);
        }
    }

    public async Task<GeneralResponseInternalDTO> GenerateJwtToken(UserResponseDTO userData)
    {
        try
        {
            var result = await _jwtService.GenerateJwtToken(userData);
            return result;
        }
        catch (Exception ex)
        {
            return new GeneralResponseInternalDTO(false, ex.Message);
        }
    }
}
