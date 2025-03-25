using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.DoctorsDto
{
    public class DoctorCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string? Info { get; set; }

        [Required]
        public string? AvailableTime { get; set; }

        [Required]
        public IFormFile profilePicture { get; set; }

        [Required]
        public int CenterId { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
