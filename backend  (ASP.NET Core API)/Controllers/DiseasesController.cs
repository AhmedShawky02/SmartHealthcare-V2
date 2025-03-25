using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.Dtos.DiseasesDto;
using SmartHealthcare.Dtos.ReviewsDto;
using SmartHealthcare.Interfaces.Diseases_Interface;
using SmartHealthcare.Interfaces.Users_Interface;
using SmartHealthcare.Mapping;
using SmartHealthcare.Models;

namespace SmartHealthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IDiseasesRepository _diseasesRepo;

        public DiseasesController(IUserRepository userRepo ,IDiseasesRepository diseasesRepo)
        {
            _userRepo = userRepo;
            _diseasesRepo = diseasesRepo;
        }

        [HttpPost("CreateDisease")]
        public async Task<IActionResult> CreateDiseases([FromBody] DiseaseCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingUser = await _userRepo.GetUserById(createDto.UserId);
                if (existingUser == null)
                {
                    return NotFound("User not Found.");
                }

                var review = new Disease()
                {
                    Name = createDto.Name,
                    UserId = createDto.UserId
                };

                await _diseasesRepo.CreateDiseasesAsync(review);

                return StatusCode(201, new { id = review.DiseaseId, message = "Disease added successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("CreateSymptom")]
        public async Task<IActionResult> CreateSymptom([FromBody] SymptomCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var symptom = new Symptom()
                {
                    Name = createDto.Name,
                };

                await _diseasesRepo.CreateSymptomAsync(symptom);

                return StatusCode(201, new { id = symptom.SymptomId, message = "Symptom added successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("CreateDiseaseSymptom")]
        public async Task<IActionResult> CreateDiseaseSymptom([FromBody] DiseaseSymptomCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingDisease = await _diseasesRepo.GetDiseaseById(createDto.DiseaseId);
                if (existingDisease == null)
                {
                    return NotFound("Disease not Found.");
                }

                var existingSymptom = await _diseasesRepo.GetSymptomById(createDto.SymptomId);
                if (existingSymptom == null)
                {
                    return NotFound("Symptom not Found.");
                }

                var existingDiseaseSymptom = await _diseasesRepo.GetDiseaseSymptomById(createDto.DiseaseId, createDto.SymptomId);
                if (existingDiseaseSymptom != null)
                {
                    return BadRequest("This symptom is already associated with the disease.");
                }


                var DiseaseSymptom = new DiseaseSymptom()
                {
                    DiseaseId = createDto.DiseaseId,
                    SymptomId = createDto.SymptomId,
                };

                await _diseasesRepo.CreateDiseaseSymptomAsync(DiseaseSymptom);

                return StatusCode(201, new { id = DiseaseSymptom.DiseaseSymptomsId, message = "Symptom added successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAllDisease")]
        public async Task<IActionResult> GetAllDisease()
        {
            try
            {
                var diseases = await _diseasesRepo.GetAllDiseaseAsync();

                if (!diseases.Any())
                {
                    return NotFound("No diseases found.");
                }

                var diseasesDto = diseases.ToDiseasesDtoConversion();
                
                return Ok(diseasesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
