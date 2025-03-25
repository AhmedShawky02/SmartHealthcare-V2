using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartHealthcare.Models;

public partial class Review
{
    [Key]
    [Column("review_id")]
    public int ReviewId { get; set; }

    [Column("rating")]
    public double? Rating { get; set; }

    [Column("comment")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Comment { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("doctor_id")]
    public int? DoctorId { get; set; }

    [ForeignKey("DoctorId")]
    [InverseProperty("Reviews")]
    public virtual Doctor? Doctor { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Reviews")]
    public virtual User? User { get; set; }
}
