using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.DiseasesDto
{
    public class SymptomCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
