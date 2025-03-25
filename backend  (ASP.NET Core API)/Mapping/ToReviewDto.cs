using SmartHealthcare.Dtos.ReviewsDto;
using SmartHealthcare.Models;

namespace SmartHealthcare.Mapping
{
    public static class ToReviewDto
    { 
        public static ReviewDto ToReviewDtoConversion(this Review review)
        {
            return new ReviewDto()
            {
                ReviewId = review.ReviewId,
                Rating = review.Rating,
                Comment = review.Comment,
                UserName = review.User.Name,
                DoctorId = review.DoctorId,
            };
        }

        public static IEnumerable<ReviewDto> ToReviewDtoConversion(this IEnumerable<Review> review)
        {
            return review.Select(review => review.ToReviewDtoConversion());
        }

    }
}
