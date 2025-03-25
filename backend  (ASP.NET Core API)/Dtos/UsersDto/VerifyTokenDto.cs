using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.UsersDto
{
    public class VerifyTokenDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
