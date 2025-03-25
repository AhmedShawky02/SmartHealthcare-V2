using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHealthcare.Dtos.DiseasesDto
{
    public class DiseaseSymptomCreateDto
    {
        [Required]
        public int DiseaseId { get; set; }

        [Required]
        public int SymptomId { get; set; }
    }
}
