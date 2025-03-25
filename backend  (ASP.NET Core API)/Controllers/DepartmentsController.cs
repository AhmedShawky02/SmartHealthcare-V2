using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartHealthcare.Dtos.DepartmentsDto;
using SmartHealthcare.Interfaces.Departments_Interface;
using SmartHealthcare.Mapping;
using SmartHealthcare.Models;
using SmartHealthcare.Repositories.Helps_Repository;

namespace SmartHealthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly Cloudinary _cloudinary;
        private readonly IDepartmentRepository _departmentRepo;

        public DepartmentsController(IDepartmentRepository departmentRepo, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            var settings = cloudinaryConfig.Value;
            _cloudinary = new Cloudinary(new Account(settings.CloudName, settings.ApiKey, settings.ApiSecret));
            _departmentRepo = departmentRepo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {
                var departments = await _departmentRepo.GetAllDepartmentsAsync();

                if (!departments.Any())
                {
                    return NotFound("No Departments found.");
                }

                var departmentsDto = departments.ToDepartmentDtoConversion();
                return Ok(departmentsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            try
            {
                var department = await _departmentRepo.GetDepartmentById(id);

                if (department == null)
                {
                    return NotFound("Department not found.");
                }

                var departmentDto = department.ToDepartmentDtoConversion();

                return Ok(departmentDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateDepartment([FromForm] CreateDepartmentDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var departmentName = await _departmentRepo.GetDepartmentByName(createDto.name!);

                if (departmentName != null)
                {
                    return BadRequest("Department name already exists.");
                }

                string? imageUrl = null;

                if (createDto.Picture != null)
                {
                    using var stream = createDto.Picture.OpenReadStream();
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(createDto.Picture.FileName, stream),
                        Folder = "Departments"
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    if (uploadResult.Error != null)
                        return BadRequest($"Image upload failed: {uploadResult.Error.Message}");

                    imageUrl = uploadResult.SecureUrl.ToString();
                }

                var department = new Department()
                {
                    Name = createDto.name!,
                    Picture = imageUrl
                };

                await _departmentRepo.CreateDepartmentAsync(department);
                return CreatedAtAction(nameof(GetDepartmentById), new { id = department.DepartmentId },
                    new { id = department.DepartmentId, message = "Medical center added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}
