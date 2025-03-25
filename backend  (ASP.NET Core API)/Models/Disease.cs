using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartHealthcare.Models;

public partial class Disease
{
    [Key]
    [Column("disease_id")]
    public int DiseaseId { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("user_id")]
    public int? UserId { get; set; }

    [InverseProperty("Disease")]
    public virtual ICollection<DiseaseSymptom> DiseaseSymptoms { get; set; } = new List<DiseaseSymptom>();

    [ForeignKey("UserId")]
    [InverseProperty("Diseases")]
    public virtual User? User { get; set; }
}
