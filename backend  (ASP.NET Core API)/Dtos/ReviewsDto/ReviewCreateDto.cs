using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.ReviewsDto
{
    public class ReviewCreateDto
    {
        [Required]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public double? Rating { get; set; }

        [Required]
        public string? Comment { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int DoctorId { get; set; }
    }
}
