using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartHealthcare.Models;

public partial class UsersVideo
{
    [Key]
    [Column("UsersVideos_id")]
    public int UsersVideosId { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("video_id")]
    public int? VideoId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UsersVideos")]
    public virtual User? User { get; set; }

    [ForeignKey("VideoId")]
    [InverseProperty("UsersVideos")]
    public virtual AwarenessVideo? Video { get; set; }
}
