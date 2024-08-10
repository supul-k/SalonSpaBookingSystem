using Microsoft.AspNetCore.Identity;
using SalonSpaBookingSystem.DatabaseAccess;
using SalonSpaBookingSystem.DTO;
using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IServices;
using SalonSpaBookingSystem.Models;

public class AuthService : IAuthService
{
    private readonly UserManager<UserModel> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _dbContext;

    public AuthService(UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _dbContext = dbContext;
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
                };

                var result = await _userManager.CreateAsync(user, registerRequest.Password);
                if (!result.Succeeded)
                {
                    return new GeneralResponseInternalDTO(false, "User Registration Failed");
                }

                // Assign role
                if (!await _roleManager.RoleExistsAsync(registerRequest.Role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(registerRequest.Role));
                }

                var roleResult = await _userManager.AddToRoleAsync(user, registerRequest.Role);
                if (!roleResult.Succeeded)
                {
                    return new GeneralResponseInternalDTO(false, "User Role creation Failed");
                }

                // Commit transaction
                await transaction.CommitAsync();

                return new GeneralResponseInternalDTO(true, "User Created Successfully");
            }
            catch
            {
                // Rollback transaction
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
