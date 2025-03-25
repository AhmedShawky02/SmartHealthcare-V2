using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartHealthcare.Models;

public partial class DiseaseSymptom
{
    [Key]
    [Column("DiseaseSymptoms_id")]
    public int DiseaseSymptomsId { get; set; }

    [Column("disease_id")]
    public int? DiseaseId { get; set; }

    [Column("symptom_id")]
    public int? SymptomId { get; set; }

    [ForeignKey("DiseaseId")]
    [InverseProperty("DiseaseSymptoms")]
    public virtual Disease? Disease { get; set; }

    [ForeignKey("SymptomId")]
    [InverseProperty("DiseaseSymptoms")]
    public virtual Symptom? Symptom { get; set; }
}
