using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Naukari_24March.Models
{
    public partial class NaukariContext : DbContext
    {
        public NaukariContext()
        {
        }

        public NaukariContext(DbContextOptions<NaukariContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EducationInfo> EducationInfos { get; set; }
        public virtual DbSet<PersonalInfo> PersonalInfos { get; set; }
        public virtual DbSet<ProfessionalInfo> ProfessionalInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=SVASAGE-LAP-047\\SQLEXPRESS;Initial Catalog=Naukari;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EducationInfo>(entity =>
            {
                entity.HasKey(e => e.EduId)
                    .HasName("PK__Educatio__1FD9496E504145F4");

                entity.ToTable("EducationInfo");

                entity.Property(e => e.EduId).HasColumnName("EduID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.DegreeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HscpassYear).HasColumnName("HSCPassYear");

                entity.Property(e => e.Hscpercentage).HasColumnName("HSCPercentage");

                entity.Property(e => e.MastersName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SscpassYear).HasColumnName("SSCPassYear");

                entity.Property(e => e.Sscpercentage).HasColumnName("SSCPercentage");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.EducationInfos)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Education__Candi__5EBF139D");
            });

            modelBuilder.Entity<PersonalInfo>(entity =>
            {
                entity.HasKey(e => e.CandidateId)
                    .HasName("PK__Personal__DF539BFC984F9E00");

                entity.ToTable("PersonalInfo");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImgPath)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResumePath)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfessionalInfo>(entity =>
            {
                entity.HasKey(e => e.InfoId)
                    .HasName("PK__Professi__4DEC9D9AF020CC60");

                entity.ToTable("ProfessionalInfo");

                entity.Property(e => e.InfoId).HasColumnName("InfoID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.Companies)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Projects)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.ProfessionalInfos)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__Candi__619B8048");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
