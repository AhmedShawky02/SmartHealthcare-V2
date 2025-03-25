using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartHealthcare.Models;

[Table("Registration")]
public partial class Registration
{
    [Key]
    [Column("registration_id")]
    public int RegistrationId { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column("password")]
    [StringLength(255)]
    public string Password { get; set; } = null!;

    [Column("age")]
    public int? Age { get; set; }

    [Column("gender")]
    [StringLength(10)]
    public string? Gender { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Registrations")]
    public virtual User? User { get; set; }
}
