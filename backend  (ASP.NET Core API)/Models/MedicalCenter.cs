using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartHealthcare.Models;

public partial class MedicalCenter
{
    [Key]
    [Column("center_id")]
    public int CenterId { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("location")]
    [StringLength(255)]
    public string? Location { get; set; }

    [InverseProperty("Center")]
    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    [InverseProperty("Center")]
    public virtual ICollection<Nurse> Nurses { get; set; } = new List<Nurse>();
}
