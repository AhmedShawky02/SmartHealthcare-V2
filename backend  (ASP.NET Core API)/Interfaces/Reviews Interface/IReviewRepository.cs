using SmartHealthcare.Models;

namespace SmartHealthcare.Interfaces.Reviews_Interface
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewById(int id);
        Task<Review> CreateReviewAsync(Review review);
        Task<List<Review>> GetAllReviewsForDoctorId(int id);
    }
}
