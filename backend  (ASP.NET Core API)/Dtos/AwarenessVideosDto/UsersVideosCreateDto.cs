using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHealthcare.Dtos.AwarenessVideosDto
{
    public class UsersVideosCreateDto
    {

        [Required]
        public int UserId { get; set; }

        [Required]
        public int VideoId { get; set; }
    }
}
