using Audiologia.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Audiologia.Infrastructure.Data
{
    public class AudiologiaDbContext : DbContext
    {
        public AudiologiaDbContext(DbContextOptions<AudiologiaDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<HearingTest> HearingTests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Patient configuration
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.IdNumber).IsRequired().HasMaxLength(20);
                entity.HasIndex(e => e.IdNumber).IsUnique();
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(150);
                entity.Property(e => e.Address).HasMaxLength(250);
                entity.Property(e => e.MedicalHistory).HasMaxLength(2000);
            });

            // Specialist configuration
            modelBuilder.Entity<Specialist>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LicenseNumber).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.LicenseNumber).IsUnique();
                entity.Property(e => e.Specialty).HasMaxLength(100);
            });

            // Appointment configuration
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Reason).HasMaxLength(500);
                entity.Property(e => e.Notes).HasMaxLength(1000);
                entity.Property(e => e.AppointmentType).HasMaxLength(50);

                entity.HasOne(a => a.Patient)
                      .WithMany(p => p.Appointments)
                      .HasForeignKey(a => a.PatientId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Specialist)
                      .WithMany(s => s.Appointments)
                      .HasForeignKey(a => a.SpecialistId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // HearingTest configuration
            modelBuilder.Entity<HearingTest>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DetailedResults).HasMaxLength(2000);
                entity.Property(e => e.Observations).HasMaxLength(1000);
                entity.Property(e => e.Recommendations).HasMaxLength(1000);

                entity.HasOne(h => h.Patient)
                      .WithMany(p => p.HearingTests)
                      .HasForeignKey(h => h.PatientId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(h => h.Appointment)
                      .WithOne(a => a.HearingTest)
                      .HasForeignKey<HearingTest>(h => h.AppointmentId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // Seed data
            modelBuilder.Entity<Specialist>().HasData(
                new Specialist
                {
                    Id = 1,
                    FirstName = "Carlos",
                    LastName = "Mendoza",
                    LicenseNumber = "AUD-001",
                    Specialty = "Clinical Audiology",
                    Phone = "555-0001",
                    Email = "c.mendoza@audiologia.com",
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Specialist
                {
                    Id = 2,
                    FirstName = "Ana",
                    LastName = "Garcia",
                    LicenseNumber = "AUD-002",
                    Specialty = "Pediatric Audiology",
                    Phone = "555-0002",
                    Email = "a.garcia@audiologia.com",
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}