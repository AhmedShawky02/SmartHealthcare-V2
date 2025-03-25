using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartHealthcare.Models;

[Table("BookingNurse")]
public partial class BookingNurse
{
    [Key]
    [Column("BookingNurse_id")]
    public int BookingNurseId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("nurse_id")]
    public int? NurseId { get; set; }

    [ForeignKey("NurseId")]
    [InverseProperty("BookingNurses")]
    public virtual Nurse? Nurse { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("BookingNurses")]
    public virtual User? User { get; set; }
}
