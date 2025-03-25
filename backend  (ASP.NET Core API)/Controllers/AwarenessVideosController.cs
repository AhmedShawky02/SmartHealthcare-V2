using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.Dtos.AwarenessVideosDto;
using SmartHealthcare.Dtos.Booking;
using SmartHealthcare.Interfaces.AwarenessVideos_Interface;
using SmartHealthcare.Interfaces.Users_Interface;
using SmartHealthcare.Mapping;
using SmartHealthcare.Models;

namespace SmartHealthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AwarenessVideosController : ControllerBase
    {
        private readonly IAwarenessVideoRepository _awarenessVideoRepo;
        private readonly IUserRepository _userRepo;

        public AwarenessVideosController(IAwarenessVideoRepository awarenessVideoRepo , IUserRepository userRepo)
        {
            _awarenessVideoRepo = awarenessVideoRepo;
            _userRepo = userRepo;
        }

        [HttpPost("CreateAwarenessVideo")]
        public async Task<IActionResult> CreateAwarenessVideos([FromBody] AwarenessVideosCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingVideo = await _awarenessVideoRepo.GetVideoByTitleAsync(createDto.Title);
                if (existingVideo != null)
                {
                    return BadRequest("A video with the same title already exists.");
                }

                var awarenessVideo = new AwarenessVideo()
                {
                    Title = createDto.Title,
                    Category = createDto.Category,
                    Duration = createDto.Duration,
                    UploadDate = DateTime.Now,
                    ViewCount = createDto.ViewCount,
                };

                await _awarenessVideoRepo.CreateAwarenessVideoAsync(awarenessVideo);

                return StatusCode(201, new { id = awarenessVideo.VideoId, message = "Video added successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("CreateUsersVideos")]
        public async Task<IActionResult> CreateUsersVideos([FromBody] UsersVideosCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingVideo = await _awarenessVideoRepo.GetVideoById(createDto.VideoId);
                if (existingVideo == null)
                {
                    return NotFound("Video not Found.");
                }

                var existingUser = await _userRepo.GetUserById(createDto.UserId);
                if (existingUser == null)
                {
                    return NotFound("User not Found.");
                }

                var userVideo = await _awarenessVideoRepo.GetUsersVideosById(createDto.UserId, createDto.VideoId);
                if (userVideo != null)
                {
                    return BadRequest("This video is already associated with this user.");
                }

                var usersVideo = new UsersVideo()
                {
                    UserId = createDto.UserId,
                    VideoId = createDto.VideoId,
                };


                await _awarenessVideoRepo.CreateUsersVideoAsync(usersVideo);

                return StatusCode(201, new { id = usersVideo.VideoId, message = "Video added successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("GetAllVideos")]
        public async Task<IActionResult> GetAllAwarenessVideos()
        {
            try
            {
                var videos = await _awarenessVideoRepo.GetAllVideos();

                if (!videos.Any())
                {
                    return NotFound("No videos found.");
                }

                var videosDto = videos.TovideosDtoConversion();

                return Ok(videosDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
