using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.DTO.InternalDTO
{
    public class GeneralResponseInternalDTO
    {
        [Required]
        public bool Status { get; set; }

        [Required]
        public string Message { get; set; }

        public object? Data { get; set; }

        public GeneralResponseInternalDTO(bool status, string message)
        {
            this.Status = status;
            this.Message = message;
        }

        public GeneralResponseInternalDTO(bool status, string message, object? data) 
        {
            this.Status = status;
            this.Message = message;
            this.Data = data;
        }
    }
}
