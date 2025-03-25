using Microsoft.EntityFrameworkCore;
using SmartHealthcare.Context;
using SmartHealthcare.Interfaces.Reviews_Interface;
using SmartHealthcare.Models;

namespace SmartHealthcare.Repositories.Reviews_Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly HealthcareDbContext _context;

        public ReviewRepository(HealthcareDbContext context)
        {
            _context = context;
        }
        public async Task<Review> CreateReviewAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<List<Review>> GetAllReviewsForDoctorId(int id)
        {
            return await _context.Reviews.Where(r => r.DoctorId == id).ToListAsync();
        }

        public async Task<Review> GetReviewById(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(x => x.ReviewId == id);
            if (review == null)
            {
                return null;
            }
            return review;
        }
    }
}
