using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartHealthcare.Dtos.DoctorsDto;
using SmartHealthcare.Dtos.NursesDto;
using SmartHealthcare.Interfaces.MedicalCenters_Interface;
using SmartHealthcare.Interfaces.Nurses_Interface;
using SmartHealthcare.Mapping;
using SmartHealthcare.Models;
using SmartHealthcare.Repositories.Helps_Repository;

namespace SmartHealthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NursesController : ControllerBase
    {
        private readonly INurseRepository _nurseRepo;
        private readonly IMedicalCenterRepository _medicalCenterRepo;
        private readonly Cloudinary _cloudinary;

        public NursesController(INurseRepository nurseRepo , IMedicalCenterRepository medicalCenterRepo, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            var settings = cloudinaryConfig.Value;
            _cloudinary = new Cloudinary(new Account(settings.CloudName, settings.ApiKey, settings.ApiSecret)); 
            _nurseRepo = nurseRepo;
            _medicalCenterRepo = medicalCenterRepo;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateNurse([FromForm] NurseCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var medicalCenter = await _medicalCenterRepo.GetmedicalCenterById(createDto.CenterId);

                if (medicalCenter == null)
                {
                    return NotFound("Medical Center not found.");
                }

                string? imageUrl = null;

                if (createDto.ProfilePicture != null)
                {
                    using var stream = createDto.ProfilePicture.OpenReadStream();
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(createDto.ProfilePicture.FileName, stream),
                        Folder = "nurses"
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    if (uploadResult.Error != null)
                        return BadRequest($"Image upload failed: {uploadResult.Error.Message}");

                    imageUrl = uploadResult.SecureUrl.ToString();
                }

                var nurse = new Nurse()
                {
                    Name = createDto.Name,
                    Info = createDto.Info,
                    ProfilePicture = imageUrl,
                    Age = createDto.Age,
                    CenterId = createDto.CenterId,
                };

                await _nurseRepo.CreateNurseAsync(nurse);

                return CreatedAtAction(nameof(GetNurseById), new { id = nurse.NurseId },
                    new { id = nurse.NurseId, message = "Nurse added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllNurses()
        {
            try
            {
                var nurses = await _nurseRepo.GetAllNursesAsync();

                if (!nurses.Any())
                {
                    return NotFound("No nurses found.");
                }

                var nursesDto = nurses.ToNurseDtoConversion();
                return Ok(nursesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNurseById([FromRoute] int id)
        {
            try
            {
                var nurse = await _nurseRepo.GetNurseById(id);

                if (nurse == null)
                {
                    return NotFound("Nurse not found.");
                }

                var nurseDto = nurse.ToNurseDtoConversion();

                return Ok(nurseDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
