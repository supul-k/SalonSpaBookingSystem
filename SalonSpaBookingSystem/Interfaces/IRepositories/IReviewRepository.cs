using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Interfaces.IRepositories
{
    public interface IReviewRepository
    {
        public Task<GeneralResponseInternalDTO> FindReviewByUserId(string userId);

        public Task<GeneralResponseInternalDTO> CreateReview(ReviewModel review);

        public Task<GeneralResponseInternalDTO> FindReviewById(string reviewId);

        public Task<GeneralResponseInternalDTO> FindReviewBySalonId(string salonSpaId);

        public Task<GeneralResponseInternalDTO> UpdateReview(ReviewModel review);

        public Task<GeneralResponseInternalDTO> DeleteReview(ReviewModel review);
    }
}
