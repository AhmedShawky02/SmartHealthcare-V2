using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartHealthcare.Models;

[Index("Email", Name = "UQ__Users__AB6E6164CFF6D3C1", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("user_id")]
    public int UserId { get; set; }

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
    public int? Gender { get; set; }

    [StringLength(10)]
    public string? ForgetToken { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<BookingDoctor> BookingDoctors { get; set; } = new List<BookingDoctor>();

    [InverseProperty("User")]
    public virtual ICollection<BookingNurse> BookingNurses { get; set; } = new List<BookingNurse>();

    [InverseProperty("User")]
    public virtual ICollection<Disease> Diseases { get; set; } = new List<Disease>();

    [InverseProperty("User")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [InverseProperty("User")]
    public virtual ICollection<UsersVideo> UsersVideos { get; set; } = new List<UsersVideo>();
}
