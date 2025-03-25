using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartHealthcare.Models;

public partial class Doctor
{
    [Key]
    [Column("doctor_id")]
    public int DoctorId { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("info")]
    [StringLength(255)]
    public string? Info { get; set; }

    [Column("profile_picture")]
    [StringLength(255)]
    public string? ProfilePicture { get; set; }

    [Column("available_time")]
    [StringLength(100)]
    public string? AvailableTime { get; set; }

    [Column("center_id")]
    public int? CenterId { get; set; }

    [Column("department_id")]
    public int? DepartmentId { get; set; }

    [InverseProperty("Doctor")]
    public virtual ICollection<BookingDoctor> BookingDoctors { get; set; } = new List<BookingDoctor>();

    [ForeignKey("CenterId")]
    [InverseProperty("Doctors")]
    public virtual MedicalCenter? Center { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("Doctors")]
    public virtual Department? Department { get; set; }

    [InverseProperty("Doctor")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
