using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.Dtos.DoctorsDto;
using SmartHealthcare.Dtos.MedicalCentersDto;
using SmartHealthcare.Interfaces.Departments_Interface;
using SmartHealthcare.Interfaces.Doctors_Interface;
using SmartHealthcare.Interfaces.MedicalCenters_Interface;
using SmartHealthcare.Interfaces.Users_Interface;
using SmartHealthcare.Mapping;
using SmartHealthcare.Models;
using Microsoft.Extensions.Options;
using SmartHealthcare.Repositories.Helps_Repository;

namespace SmartHealthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {

        private readonly Cloudinary _cloudinary;
        private readonly IDoctorRepository _doctorRepo;
        private readonly IMedicalCenterRepository _medicalCenterRepo;
        private readonly IDepartmentRepository _departmentRepository;

        public DoctorsController(IDoctorRepository doctorRepo,
            IMedicalCenterRepository medicalCenterRepo,
            IDepartmentRepository departmentRepository,
            IOptions<CloudinarySettings> cloudinaryConfig)
        {
            var settings = cloudinaryConfig.Value;
            _cloudinary = new Cloudinary(new Account(settings.CloudName, settings.ApiKey, settings.ApiSecret));
            _doctorRepo = doctorRepo;
            _medicalCenterRepo = medicalCenterRepo;
            _departmentRepository = departmentRepository;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateDoctor([FromForm] DoctorCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var medicalCenter = await _medicalCenterRepo.GetmedicalCenterById(createDto.CenterId);
                if (medicalCenter == null)
                    return NotFound("Medical Center not found.");

                var department = await _departmentRepository.GetDepartmentById(createDto.DepartmentId);
                if (department == null)
                    return NotFound("Department not found.");

                string? imageUrl = null;

                if (createDto.profilePicture != null)
                {
                    using var stream = createDto.profilePicture.OpenReadStream();
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(createDto.profilePicture.FileName, stream),
                        Folder = "doctors"
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    if (uploadResult.Error != null)
                        return BadRequest($"Image upload failed: {uploadResult.Error.Message}");

                    imageUrl = uploadResult.SecureUrl.ToString();
                }

                var doctor = new Doctor()
                {
                    Name = createDto.Name,
                    Info = createDto.Info,
                    AvailableTime = createDto.AvailableTime,
                    ProfilePicture = imageUrl,
                    CenterId = createDto.CenterId,
                    DepartmentId = createDto.DepartmentId,
                };

                await _doctorRepo.CreateDoctorAsync(doctor);

                return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.DoctorId },
                    new { id = doctor.DoctorId, message = "Doctor added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                var doctors = await _doctorRepo.GetAllDoctorsAsync();

                if (!doctors.Any())
                {
                    return NotFound("No doctors found.");
                }

                var doctorsDto = doctors.ToDoctorDtoConversion();
                return Ok(doctorsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById([FromRoute] int id)
        {
            try
            {
                var doctor = await _doctorRepo.GetDoctorById(id);

                if (doctor == null)
                {
                    return NotFound("Doctor not found.");
                }

                var doctorDto = doctor.ToDoctorDtoConversion();

                return Ok(doctorDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[HttpPost("Create")]
        //public async Task<IActionResult> CreateDoctor([FromForm] DoctorCreateDto createDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return BadRequest(ModelState);

        //        var medicalCenter = await _medicalCenterRepo.GetmedicalCenterById(createDto.CenterId);

        //        if (medicalCenter == null)
        //        {
        //            return NotFound("Medical Center not found.");
        //        }

        //        var department = await _departmentRepository.GetDepartmentById(createDto.DepartmentId);

        //        if (department == null)
        //        {
        //            return NotFound("Department not found.");
        //        }

        //        string? filePath = null;

        //        if (createDto.profilePicture != null)
        //        {
        //            var fileName = $"{Guid.NewGuid()}_{createDto.profilePicture.FileName}";

        //            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "DoctorsPictures");

        //            if (!Directory.Exists(folderPath))
        //            {
        //                Directory.CreateDirectory(folderPath);
        //            }

        //            filePath = Path.Combine("DoctorsPictures", fileName);

        //            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                await createDto.profilePicture.CopyToAsync(stream);
        //            }

        //        }

        //        var doctor = new Doctor()
        //        {
        //            Name = createDto.Name,
        //            Info = createDto.Info,
        //            AvailableTime = createDto.AvailableTime,
        //            ProfilePicture = filePath,
        //            CenterId = createDto.CenterId,
        //            DepartmentId = createDto.DepartmentId,
        //        };

        //        await _doctorRepo.CreateDoctorAsync(doctor);

        //        return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.DoctorId },
        //            new { id = doctor.DoctorId, message = "Doctor added successfully." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}


        [HttpGet("by-department/{departmentId}")]
        public async Task<IActionResult> GetDoctorsByDepartment([FromRoute] int departmentId)
        {
            try
            {
                var doctors = await _doctorRepo.GetDoctorsByDepartmentId(departmentId);

                if (!doctors.Any())
                {
                    return NotFound("No doctors found.");
                }

                var doctorsDto = doctors.ToDoctorDtoConversion();
                return Ok(doctorsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}
