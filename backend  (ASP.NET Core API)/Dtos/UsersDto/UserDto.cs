using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SmartHealthcare.Models;
using SmartHealthcare.Dtos.AwarenessVideosDto;

namespace SmartHealthcare.Dtos.UsersDto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; } 
        public int? Age { get; set; }
        public int? Gender { get; set; }
        public List<videosDto> videos { get; set; }
    }
}
