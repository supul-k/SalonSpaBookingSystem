using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using SalonSpaBookingSystem.DatabaseAccess;
using SalonSpaBookingSystem.DTO;
using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Models;
using System.Data;

namespace SalonSpaBookingSystem.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        public AuthRepository(
            UserManager<UserModel> userManager, 
            RoleManager<IdentityRole> roleManager, 
            SignInManager<UserModel> signInManager,
            ApplicationDbContext dbContext
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        public async Task<GeneralResponseInternalDTO> UserExist(string Email)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var existingUser = await _userManager.FindByEmailAsync(Email);
                    if (existingUser == null)
                    {
                        return new GeneralResponseInternalDTO(false, "User does not exist");
                    }

                    var userRole = await _userManager.GetRolesAsync(existingUser);
                    var role = userRole.FirstOrDefault();
                    if (role == null)
                    {
                        return new GeneralResponseInternalDTO(false, "User role not available");
                    }

                    // Map UserModel to UserResponseDTO
                    var userDto = new UserResponseDTO
                    {
                        Id = existingUser.Id,
                        FirstName = existingUser.FirstName,
                        LastName = existingUser.LastName,
                        UserName = existingUser.UserName,
                        Email = existingUser.Email,
                        PhoneNumber = existingUser.PhoneNumber,
                        Role = role
                    };

                    // Commit transaction
                    await transaction.CommitAsync();
                    return new GeneralResponseInternalDTO(true, "User exists", userDto);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new GeneralResponseInternalDTO(false, ex.Message);
                }
            }            
        }        

        public async Task<GeneralResponseInternalDTO> CreateUserAsync(UserModel user, string Password)
        {
            try
            {
                var result = await _userManager.CreateAsync(user, Password);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return new GeneralResponseInternalDTO(false, $"User Creation Failed: {errors}");
                }

                return new GeneralResponseInternalDTO(true, "User Created Successfully");
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
                var exists = await _roleManager.RoleExistsAsync(Role);
                if (!exists)
                {
                    return new GeneralResponseInternalDTO(false, "User role does not exist");
                }

                return new GeneralResponseInternalDTO(true, "Role Exist");
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> AssignRolesAsync(UserModel user, string Role)
        {
            try
            {
                var roleResult = await _userManager.AddToRoleAsync(user, Role);
                if (!roleResult.Succeeded)
                {
                    var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                    return new GeneralResponseInternalDTO(false, $"Role Assignment Failed: {errors}");
                }
                return new GeneralResponseInternalDTO(true, "User Combined with role");
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
                var result = await _signInManager.PasswordSignInAsync(
                    UserName,
                    userSignInRequest.Password,
                    isPersistent: userSignInRequest.RememberMe,
                    lockoutOnFailure: false
                );

                if (result.Succeeded)
                {
                    return new GeneralResponseInternalDTO(true, "Sign-in successful");
                }
                else if (result.IsLockedOut)
                {
                    return new GeneralResponseInternalDTO(false, "User account is locked out");
                }
                else
                {
                    return new GeneralResponseInternalDTO(false, "Invalid login attempt");
                }
            }      
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
