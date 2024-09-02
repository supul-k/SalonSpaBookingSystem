using Microsoft.EntityFrameworkCore;
using SalonSpaBookingSystem.DatabaseAccess;
using SalonSpaBookingSystem.DTO;
using SalonSpaBookingSystem.DTO.InternalDTO;
using SalonSpaBookingSystem.Interfaces.IRepositories;
using SalonSpaBookingSystem.Models;

namespace SalonSpaBookingSystem.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponseInternalDTO> FindReviewByUserId(string userId)
        {
            try
            {
                var result = await _context.Reviews
                    .Where(r => r.UserId == userId)
                    .ToListAsync();
                if (!result.Any())
                {
                    return new GeneralResponseInternalDTO(false, "No reviews under this user");
                }

                return new GeneralResponseInternalDTO(true, "Reviews found under this user");

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
                await _context.Reviews.AddAsync(review);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "Review Created Successfully");
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
                var result = await _context.Reviews.FindAsync(reviewId);
                if (result == null)
                {
                    return new GeneralResponseInternalDTO(false, "Reviews not found");
                }

                return new GeneralResponseInternalDTO(true, "Review found", result);
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
                var result = await _context.Reviews
                    .Where(r => r.SalonSpaId == salonSpaId)
                    .Select(r => new ReviewResponseDTO
                    {
                        ReviewId = r.ReviewId,
                        SalonSpaId = r.SalonSpaId,
                        Comment = r.Comment,
                        Rating = r.Rating
                    })
                    .ToListAsync();
                if (!result.Any())
                {
                    return new GeneralResponseInternalDTO(false, "No reviews under this salon");
                }

                return new GeneralResponseInternalDTO(true, "Reviews found under this salon", result);

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
                _context.Reviews.Update(review);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "Review Updated successfully");
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
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "Review deleted successfully");
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
