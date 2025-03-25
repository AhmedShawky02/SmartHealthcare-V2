using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.ReviewsDto
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public double? Rating { get; set; }
        public string? Comment { get; set; }
        public string? UserName { get; set; }
        public int? DoctorId { get; set; }
    }
}
