using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.DiseasesDto
{
    public class DiseasesDto
    {
        public int DiseaseId { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }

        public List<SymptomDto> Symptom { get; set; }
    }
}
