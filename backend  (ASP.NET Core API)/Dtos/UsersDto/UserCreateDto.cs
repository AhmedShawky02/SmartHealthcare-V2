using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.UsersDto
{
    public class UserCreateDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public int? Age { get; set; }

        [Required]
        public int? Gender { get; set; }
    }
}
