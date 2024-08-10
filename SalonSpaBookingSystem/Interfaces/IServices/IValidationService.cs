using SalonSpaBookingSystem.DTO.InternalDTO;

namespace SalonSpaBookingSystem.Interfaces.IServices
{
    public interface IValidationService
    {
        public Task<GeneralResponseInternalDTO> ValidatePassword(string password);

        public Task<GeneralResponseInternalDTO> ValidateEmail(string email);
    }
}
