using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.AwarenessVideosDto
{
    public class AwarenessVideosCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public int ViewCount { get; set; }
    }
}
