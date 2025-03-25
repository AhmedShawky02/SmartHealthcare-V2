using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartHealthcare.Models;

public partial class Nurse
{
    [Key]
    [Column("nurse_id")]
    public int NurseId { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("info")]
    [StringLength(255)]
    public string? Info { get; set; }

    [Column("profile_picture")]
    [StringLength(255)]
    public string? ProfilePicture { get; set; }

    [Column("age")]
    public int? Age { get; set; }

    [Column("center_id")]
    public int? CenterId { get; set; }

    [InverseProperty("Nurse")]
    public virtual ICollection<BookingNurse> BookingNurses { get; set; } = new List<BookingNurse>();

    [ForeignKey("CenterId")]
    [InverseProperty("Nurses")]
    public virtual MedicalCenter? Center { get; set; }
}
