using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.MedicalCenterDto
{
    public class MedicalCenterDto
    {
        public int CenterId { get; set; }
        public string Name { get; set; } 
        public string? Location { get; set; }
    }
}
