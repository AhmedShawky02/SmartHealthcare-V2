using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartHealthcare.Models;

[Table("BookingDoctor")]
public partial class BookingDoctor
{
    [Key]
    [Column("BookingDoctor_id")]
    public int BookingDoctorId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("doctor_id")]
    public int? DoctorId { get; set; }

    [ForeignKey("DoctorId")]
    [InverseProperty("BookingDoctors")]
    public virtual Doctor? Doctor { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("BookingDoctors")]
    public virtual User? User { get; set; }
}
