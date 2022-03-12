using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _11_March_Practical.Models
{
    public partial class ClinicContext : DbContext
    {
        public ClinicContext()
        {
        }

        public ClinicContext(DbContextOptions<ClinicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DailyReport> DailyReports { get; set; } = null!;
        public virtual DbSet<MedicalInfo> MedicalInfos { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=SVASAGE-LAP-047\\SQLEXPRESS;Initial Catalog=Clinic;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DailyReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__DailyRep__D5BD48E5BC00F76D");

                entity.ToTable("DailyReport");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.DailyReports)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DailyRepo__Patie__7F2BE32F");
            });

            modelBuilder.Entity<MedicalInfo>(entity =>
            {
                entity.HasKey(e => e.InfoId)
                    .HasName("PK__MedicalI__4DEC9D9A546675FA");

                entity.ToTable("MedicalInfo");

                entity.Property(e => e.InfoId).HasColumnName("InfoID");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.Bp).HasColumnName("BP");

                entity.Property(e => e.CholestrolHdl).HasColumnName("Cholestrol_HDL");

                entity.Property(e => e.CholestrolLdl).HasColumnName("Cholestrol_LDL");

                entity.Property(e => e.Medicine)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Patientname)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SugarFast).HasColumnName("Sugar_Fast");

                entity.Property(e => e.SugarPostFast).HasColumnName("Sugar_PostFast");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.MedicalInfos)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MedicalIn__Patie__7C4F7684");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.PatientId)
                    .ValueGeneratedNever()
                    .HasColumnName("PatientID");

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
