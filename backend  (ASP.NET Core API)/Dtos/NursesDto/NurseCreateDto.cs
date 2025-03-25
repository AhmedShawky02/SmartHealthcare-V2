using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.NursesDto
{
    public class NurseCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string? Info { get; set; }

        [Required]
        public IFormFile ProfilePicture { get; set; }

        [Required]
        public int? Age { get; set; }

        [Required]
        public int CenterId { get; set; }

    }
}
