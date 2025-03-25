using SmartHealthcare.Dtos.AwarenessVideosDto;
using SmartHealthcare.Dtos.UsersDto;
using SmartHealthcare.Models;

namespace SmartHealthcare.Mapping
{
    public static class ToUserDto
    {
        public static UserDto ToUserDtoConversion(this User user)
        {
            return new UserDto()
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Age = user.Age,
                Gender = user.Gender,
                videos = user.UsersVideos.Select(x => new videosDto()
                {
                    VideoId = x.Video.VideoId,
                    Title = x.Video.Title,
                    Category = x.Video.Category,
                    Duration = x.Video.Duration,
                    UploadDate = x.Video.UploadDate,
                    ViewCount = x.Video.ViewCount
                }).ToList()
            };
        }

        public static IEnumerable<UserDto> ToUserDtoConversion(this IEnumerable<User> user)
        {
            return user.Select(user => user.ToUserDtoConversion());
        }

    }
}
