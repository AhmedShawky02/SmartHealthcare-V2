using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.MedicalCentersDto
{
    public class CreateMedicalCenterDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string? Location { get; set; }
    }
}
