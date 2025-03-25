using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.UsersDto
{
    public class ResetPasswordDto
    {
        [Required]
        public string? TokenOTP { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? ConfirmPassword { get; set; }
    }
}
