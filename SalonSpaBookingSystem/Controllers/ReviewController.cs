using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalonSpaBookingSystem.DTO;
using SalonSpaBookingSystem.Interfaces.IServices;
using SalonSpaBookingSystem.Models;
using SalonSpaBookingSystem.Services;
using System.Security.Claims;

namespace SalonSpaBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly ISalonSpaService _salonSpaService;

        public ReviewController(IReviewService reviverService, ISalonSpaService salonSpaService)
        {
            _reviewService = reviverService;
            _salonSpaService = salonSpaService;
        }

        [HttpPost("create-review", Name = "CreateReview")]
        public async Task<IActionResult> CreateReview([FromBody] ReviewCreateRequestDTO request)
        {
            try
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized(new GeneralResposnseDTO(false, "User not authenticated"));
                }

                var salonSpaResult = await _salonSpaService.FindSalonSpa(request.SalonSpaId);
                if (!salonSpaResult.Status)
                {
                    return BadRequest(salonSpaResult);
                }

                if (request.Rating <= 0 && request.Rating >= 5)
                {
                    return BadRequest(new GeneralResposnseDTO(false, "Rating must be between 0 and 5"));
                }

                ReviewModel review = new ReviewModel();
                review.ReviewId = Guid.NewGuid().ToString();
                review.UserId = userId;
                review.SalonSpaId = request.SalonSpaId;
                review.Rating = request.Rating;
                review.Comment = request.Comment;
                review.CreatedAt = DateTime.UtcNow;
                review.UpdatedAt = DateTime.UtcNow;

                var result = await _reviewService.CreateReview(review);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Created(string.Empty, result);

            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }

        [HttpGet("get-reviews-bySalon/{salonSpaId}", Name ="GetReviewsBySalonId")]
        public async Task<IActionResult> FetchReviewsBySalonId(string salonSpaId)
        {
            try
            {
                var salonSpaResult = await _salonSpaService.FindSalonSpa(salonSpaId);
                if (!salonSpaResult.Status)
                {
                    return BadRequest(salonSpaResult);
                }

                var result = await _reviewService.FindReviewBySalonId(salonSpaId);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }

        [HttpPut("update-review/{reviewId}", Name ="UpdateReview")]
        public async Task<IActionResult> UpdateReview(string reviewId, [FromBody] ReviewUpdateRequestDTO request)
        {
            try
            {
                var reviewResult = await _reviewService.FindReviewById(reviewId);
                if (!reviewResult.Status)
                {
                    return BadRequest(reviewResult);
                }

                if (request.Rating.HasValue && request.Rating <= 0 && request.Rating >= 5)
                {
                    return BadRequest(new GeneralResposnseDTO(false, "Rating must be between 0 and 5"));
                }

                ReviewModel review = reviewResult.Data as ReviewModel;
                if (request.Rating.HasValue) review.Rating = request.Rating.Value;
                if (!string.IsNullOrEmpty(request.Comment)) review.Comment = request.Comment;
                review.UpdatedAt = DateTime.UtcNow;

                var result = await _reviewService.UpdateReview(review);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }

        [HttpDelete("delete-review/{reviewId}", Name ="DeleteReview")]
        public async Task<IActionResult> DeleteBooking(string reviewId)
        {
            try
            {
                var reviewResult = await _reviewService.FindReviewById(reviewId);
                if (!reviewResult.Status)
                {
                    return BadRequest(reviewResult);
                }

                var review = reviewResult.Data as ReviewModel;

                var result = await _reviewService.DeleteReview(review);
                if (!result.Status)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResposnseDTO(false, ex.Message));
            }
        }
    }
}
