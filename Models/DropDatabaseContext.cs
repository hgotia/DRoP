using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Drop.Web.models
{
    public partial class DropDatabaseContext : DbContext
    {
        public DropDatabaseContext()
        {
        }

        public DropDatabaseContext(DbContextOptions<DropDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminUser> AdminUsers { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<DonorQuestion> DonorQuestions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=ASUS-G0T14;Initial Catalog=DropDatabase;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__AdminUse__1788CCAC848EA372");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DonorId).HasColumnName("DonorID");

                entity.HasOne(d => d.Donor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DonorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__Donor__47DBAE45");
            });

            modelBuilder.Entity<Donor>(entity =>
            {
                entity.Property(e => e.DonorId).HasColumnName("DonorID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(22)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DonorQuestion>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PK__DonorQue__0DC06F8CC73C7A6F");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
