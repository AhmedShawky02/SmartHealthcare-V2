using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.DepartmentsDto
{
    public class CreateDepartmentDto
    {
        [Required]
        public string? name {  get; set; }

        [Required]
        public IFormFile? Picture {  get; set; }
    }
}
