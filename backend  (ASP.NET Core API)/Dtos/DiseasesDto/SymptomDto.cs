using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.DiseasesDto
{
    public class SymptomDto
    {
        public int SymptomId { get; set; }
        public string Name { get; set; } 
    }
}
