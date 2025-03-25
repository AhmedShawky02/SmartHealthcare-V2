using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartHealthcare.Models;

public partial class AwarenessVideo
{
    [Key]
    [Column("video_id")]
    public int VideoId { get; set; }

    [Column("title")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Title { get; set; }

    [Column("category")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Category { get; set; }

    [Column("duration")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Duration { get; set; }

    [Column("upload_date", TypeName = "datetime")]
    public DateTime? UploadDate { get; set; }

    [Column("view_count")]
    public int? ViewCount { get; set; }

    [InverseProperty("Video")]
    public virtual ICollection<UsersVideo> UsersVideos { get; set; } = new List<UsersVideo>();
}
