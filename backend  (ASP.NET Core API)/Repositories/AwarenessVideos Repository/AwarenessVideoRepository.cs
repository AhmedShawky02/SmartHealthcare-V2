using Microsoft.EntityFrameworkCore;
using SmartHealthcare.Context;
using SmartHealthcare.Interfaces.AwarenessVideos_Interface;
using SmartHealthcare.Models;

namespace SmartHealthcare.Repositories.AwarenessVideos_Repository
{
    public class AwarenessVideoRepository : IAwarenessVideoRepository
    {
        private readonly HealthcareDbContext _context;

        public AwarenessVideoRepository(HealthcareDbContext context)
        {
            _context = context;
        }
        public async Task<AwarenessVideo> CreateAwarenessVideoAsync(AwarenessVideo video)
        {
            await _context.AwarenessVideos.AddAsync(video);
            await _context.SaveChangesAsync();  
            return video;
        }

        public async Task<UsersVideo> CreateUsersVideoAsync(UsersVideo UsersVideo)
        {
            await _context.UsersVideos.AddAsync(UsersVideo);
            await _context.SaveChangesAsync();
            return UsersVideo;
        }

        public async Task<List<AwarenessVideo>> GetAllVideos()
        {
            return await _context.AwarenessVideos.ToListAsync();
        }

        public async Task<UsersVideo> GetUsersVideosById(int userId, int videoId)
        {
            var video = await _context.UsersVideos.FirstOrDefaultAsync(x => x.UserId == userId && x.VideoId == videoId);
            if (video == null)
            {
                return null;
            }
            return video;
        }

        public async Task<AwarenessVideo> GetVideoById(int id)
        {
            var video = await _context.AwarenessVideos.FirstOrDefaultAsync(x => x.VideoId == id);
            if (video == null)
            {
                return null;
            }
            return video;
        }

        public async Task<AwarenessVideo> GetVideoByTitleAsync(string title)
        {
            var video = await _context.AwarenessVideos.FirstOrDefaultAsync(x => x.Title.ToLower() == title.ToLower());
            if (video == null)
            {
                return null;
            }
            return video;
        }
    }
}
