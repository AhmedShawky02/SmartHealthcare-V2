using SmartHealthcare.Dtos.AwarenessVideosDto;
using SmartHealthcare.Models;

namespace SmartHealthcare.Mapping
{
    public static class TovideosDto
    {
        public static videosDto TovideosDtoConversion(this AwarenessVideo awarenessVideo)
        {
            return new videosDto()
            {
                VideoId = awarenessVideo.VideoId,
                Title = awarenessVideo.Title,
                Category = awarenessVideo.Category, 
                Duration = awarenessVideo.Duration,
                UploadDate = awarenessVideo.UploadDate,
                ViewCount = awarenessVideo.ViewCount,
            };
        }

        public static IEnumerable<videosDto> TovideosDtoConversion(this IEnumerable<AwarenessVideo> awarenessVideo)
        {
            return awarenessVideo.Select(awarenessVideo => awarenessVideo.TovideosDtoConversion());
        }

    }
}
