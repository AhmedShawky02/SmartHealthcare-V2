using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.Dtos.DepartmentsDto;
using SmartHealthcare.Dtos.MedicalCentersDto;
using SmartHealthcare.Interfaces.MedicalCenters_Interface;
using SmartHealthcare.Mapping;
using SmartHealthcare.Models;

namespace SmartHealthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalCentersController : ControllerBase
    {
        private readonly IMedicalCenterRepository _medicalCenterRepo;

        public MedicalCentersController(IMedicalCenterRepository medicalCenterRepo)
        {
            _medicalCenterRepo = medicalCenterRepo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllMedicalCenters()
        {
            try
            {
                var medicalCenters = await _medicalCenterRepo.GetAllmedicalCentersAsync();

                if (!medicalCenters.Any())
                {
                    return NotFound("No medical centers found.");
                }

                var medicalCentersDto = medicalCenters.ToMedicalCenterDtoConversion();
                return Ok(medicalCentersDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalCenterById([FromRoute] int id)
        {
            try
            {
                var medicalCenter = await _medicalCenterRepo.GetmedicalCenterById(id);

                if (medicalCenter == null)
                {
                    return NotFound("Medical Center not found.");
                }

                var medicalCenterDto = medicalCenter.ToMedicalCenterDtoConversion();

                return Ok(medicalCenterDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateMedicalCenter([FromBody] CreateMedicalCenterDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingMedicalCenter = await _medicalCenterRepo.GetmedicalCenterByName(createDto.Name);

                if (existingMedicalCenter != null)
                {
                    return BadRequest("Medical center name already exists.");
                }

                var medicalCenter = new MedicalCenter()
                {
                    Name = createDto.Name,
                    Location = createDto.Location,                     
                };

                await _medicalCenterRepo.CreateMedicalCenterAsync(medicalCenter);

                return CreatedAtAction(nameof(GetMedicalCenterById), new { id = medicalCenter.CenterId },
                    new { id = medicalCenter.CenterId, message = "Medical center added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
