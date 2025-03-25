using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartHealthcare.Models;

namespace SmartHealthcare.Context;

public partial class HealthcareDbContext : DbContext
{
    public HealthcareDbContext(DbContextOptions<HealthcareDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AwarenessVideo> AwarenessVideos { get; set; }

    public virtual DbSet<BookingDoctor> BookingDoctors { get; set; }

    public virtual DbSet<BookingNurse> BookingNurses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Disease> Diseases { get; set; }

    public virtual DbSet<DiseaseSymptom> DiseaseSymptoms { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<MedicalCenter> MedicalCenters { get; set; }

    public virtual DbSet<Nurse> Nurses { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Symptom> Symptoms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersVideo> UsersVideos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AwarenessVideo>(entity =>
        {
            entity.HasKey(e => e.VideoId).HasName("PK__Awarenes__E8F11E10C5944B5C");
        });

        modelBuilder.Entity<BookingDoctor>(entity =>
        {
            entity.HasKey(e => e.BookingDoctorId).HasName("PK__BookingD__CA0B42E20C19A24D");

            entity.HasOne(d => d.Doctor).WithMany(p => p.BookingDoctors).HasConstraintName("FK__BookingDo__docto__4CA06362");

            entity.HasOne(d => d.User).WithMany(p => p.BookingDoctors).HasConstraintName("FK__BookingDo__user___4D94879B");
        });

        modelBuilder.Entity<BookingNurse>(entity =>
        {
            entity.HasKey(e => e.BookingNurseId).HasName("PK__BookingN__612B32DC60855A36");

            entity.HasOne(d => d.Nurse).WithMany(p => p.BookingNurses).HasConstraintName("FK__BookingNu__nurse__534D60F1");

            entity.HasOne(d => d.User).WithMany(p => p.BookingNurses).HasConstraintName("FK__BookingNu__user___5441852A");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__C2232422FE2AEEE7");
        });

        modelBuilder.Entity<Disease>(entity =>
        {
            entity.HasKey(e => e.DiseaseId).HasName("PK__Diseases__156270657C24BF41");

            entity.HasOne(d => d.User).WithMany(p => p.Diseases).HasConstraintName("FK__Diseases__user_i__571DF1D5");
        });

        modelBuilder.Entity<DiseaseSymptom>(entity =>
        {
            entity.HasKey(e => e.DiseaseSymptomsId).HasName("PK__DiseaseS__35002435B3AACCD6");

            entity.HasOne(d => d.Disease).WithMany(p => p.DiseaseSymptoms).HasConstraintName("FK__DiseaseSy__disea__5BE2A6F2");

            entity.HasOne(d => d.Symptom).WithMany(p => p.DiseaseSymptoms).HasConstraintName("FK__DiseaseSy__sympt__5CD6CB2B");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctors__F3993564C699E23E");

            entity.HasOne(d => d.Center).WithMany(p => p.Doctors).HasConstraintName("FK__Doctors__center___48CFD27E");

            entity.HasOne(d => d.Department).WithMany(p => p.Doctors).HasConstraintName("FK__Doctors__departm__49C3F6B7");
        });

        modelBuilder.Entity<MedicalCenter>(entity =>
        {
            entity.HasKey(e => e.CenterId).HasName("PK__MedicalC__290A2887CF590F70");
        });

        modelBuilder.Entity<Nurse>(entity =>
        {
            entity.HasKey(e => e.NurseId).HasName("PK__Nurses__9BADE499D0353832");

            entity.HasOne(d => d.Center).WithMany(p => p.Nurses).HasConstraintName("FK__Nurses__center_i__5070F446");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__60883D9089AC4CA5");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Reviews).HasConstraintName("FK__Reviews__doctor___6383C8BA");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews).HasConstraintName("FK__Reviews__user_id__628FA481");
        });

        modelBuilder.Entity<Symptom>(entity =>
        {
            entity.HasKey(e => e.SymptomId).HasName("PK__Symptoms__7A85ADB8A39A6E56");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370FEBBB1DC4");
        });

        modelBuilder.Entity<UsersVideo>(entity =>
        {
            entity.HasKey(e => e.UsersVideosId).HasName("PK__UsersVid__F2F3DB45FAD5F2DE");

            entity.HasOne(d => d.User).WithMany(p => p.UsersVideos).HasConstraintName("FK__UsersVide__user___68487DD7");

            entity.HasOne(d => d.Video).WithMany(p => p.UsersVideos).HasConstraintName("FK__UsersVide__video__693CA210");
        });

    }

}
