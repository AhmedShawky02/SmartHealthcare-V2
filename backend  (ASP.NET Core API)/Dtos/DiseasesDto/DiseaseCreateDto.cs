using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.DiseasesDto
{
    public class DiseaseCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
