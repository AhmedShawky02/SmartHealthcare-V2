using SmartHealthcare.Models;

namespace SmartHealthcare.Interfaces.AwarenessVideos_Interface
{
    public interface IAwarenessVideoRepository
    {
        Task<AwarenessVideo> CreateAwarenessVideoAsync(AwarenessVideo video);
        Task<UsersVideo> CreateUsersVideoAsync(UsersVideo UsersVideo);

        Task<AwarenessVideo> GetVideoByTitleAsync(string title);

        Task<AwarenessVideo> GetVideoById(int id);
        Task<List<AwarenessVideo>> GetAllVideos();

        Task<UsersVideo> GetUsersVideosById(int userId, int videoId);
    }
}
