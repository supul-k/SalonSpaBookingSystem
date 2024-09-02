using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Interfaces.IServices;
using SalonSpaBookingSystem.Models;
using SalonSpaBookingSystem.Repositories;

namespace SalonSpaBookingSystem.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<GeneralResponseInternalDTO> FindReviewByUserId(string userId)
        {
            try
            {
                var result = await _reviewRepository.FindReviewByUserId(userId);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> CreateReview(ReviewModel review)
        {
            try
            {
                var result = await _reviewRepository.CreateReview(review);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> FindReviewById(string reviewId)
        {
            try
            {
                var result = await _reviewRepository.FindReviewById(reviewId);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> FindReviewBySalonId(string salonSpaId)
        {
            try
            {
                var result = await _reviewRepository.FindReviewBySalonId(salonSpaId);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> UpdateReview(ReviewModel review)
        {
            try
            {
                var result = await _reviewRepository.UpdateReview(review);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> DeleteReview(ReviewModel review)
        {
            try
            {
                var result = await _reviewRepository.DeleteReview(review);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
