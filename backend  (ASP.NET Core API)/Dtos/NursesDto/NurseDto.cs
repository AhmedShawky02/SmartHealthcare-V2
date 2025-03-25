using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.NursesDto
{
    public class NurseDto
    {
        public int NurseId { get; set; }
        public string Name { get; set; }
        public string? Info { get; set; }
        public string? ProfilePicture { get; set; }
        public int? Age { get; set; }
        public string CenterName { get; set; }
    }
}
