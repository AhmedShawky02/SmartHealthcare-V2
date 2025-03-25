using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.UsersDto
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
