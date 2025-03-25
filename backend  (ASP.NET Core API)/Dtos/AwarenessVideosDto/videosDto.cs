using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Dtos.AwarenessVideosDto
{
    public class videosDto
    {
        public int VideoId { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public string? Duration { get; set; }
        public DateTime? UploadDate { get; set; }
        public int? ViewCount { get; set; }
    }
}
