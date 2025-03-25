using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.Dtos.DoctorsDto;
using SmartHealthcare.Dtos.ReviewsDto;
using SmartHealthcare.Interfaces.Doctors_Interface;
using SmartHealthcare.Interfaces.Reviews_Interface;
using SmartHealthcare.Interfaces.Users_Interface;
using SmartHealthcare.Mapping;
using SmartHealthcare.Models;

namespace SmartHealthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IUserRepository _userRepo;
        private readonly IDoctorRepository _doctorRepo;

        public ReviewsController(IReviewRepository reviewRepo,
            IUserRepository userRepo,
            IDoctorRepository doctorRepo)
        {
            _reviewRepo = reviewRepo;
            _userRepo = userRepo;
            _doctorRepo = doctorRepo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllReviews()
        {
            try
            {
                var reviews = await _reviewRepo.GetAllReviewsAsync();

                if (!reviews.Any())
                {
                    return NotFound("No reviews found.");
                }

                var reviewsDto = reviews.ToReviewDtoConversion();

                return Ok(reviewsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById([FromRoute] int id)
        {
            try
            {
                var review = await _reviewRepo.GetReviewById(id);

                if (review == null)
                {
                    return NotFound("Review not found.");
                }

                var reviewDto = review.ToReviewDtoConversion();

                return Ok(reviewDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("reviews/{doctorId}")]
        public async Task<IActionResult> GetDoctorReviews(int doctorId)
        {
            try
            {
                var doctor = await _doctorRepo.GetDoctorById(doctorId);
                if (doctor == null)
                {
                    return NotFound("Doctor not found.");
                }

                var reviews = await _reviewRepo.GetAllReviewsForDoctorId(doctorId);
                if (reviews.Count == 0)
                {
                    return NotFound("No reviews found for this doctor.");
                }

                var reviewDto = reviews.ToReviewDtoConversion();

                return Ok(reviewDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateReview([FromBody] ReviewCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingUser = await _userRepo.GetUserById(createDto.UserId);
                if (existingUser == null)
                {
                    return NotFound("User not Found.");
                }

                var existingDoctor = await _doctorRepo.GetDoctorById(createDto.DoctorId);
                if (existingDoctor == null)
                {
                    return NotFound("Doctor not Found.");
                }

                var review = new Review()
                {
                    Rating = createDto.Rating,
                    Comment = createDto.Comment,
                    UserId = createDto.UserId,
                    DoctorId = createDto.DoctorId,
                };
                await _reviewRepo.CreateReviewAsync(review);

                return CreatedAtAction(nameof(GetReviewById), new { id = review.ReviewId },
                    new { id = review.ReviewId, message = "Review added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
