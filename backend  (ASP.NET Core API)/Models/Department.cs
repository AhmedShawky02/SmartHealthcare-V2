using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartHealthcare.Models;

public partial class Department
{
    [Key]
    [Column("department_id")]
    public int DepartmentId { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("picture")]
    [StringLength(255)]
    public string? Picture { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
