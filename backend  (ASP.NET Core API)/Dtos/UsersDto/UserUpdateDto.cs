using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.UsersDto
{
    public class UserUpdateDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public int? Age { get; set; }
    }
}
