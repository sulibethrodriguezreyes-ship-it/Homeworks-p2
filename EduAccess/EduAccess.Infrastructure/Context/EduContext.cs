using Microsoft.EntityFrameworkCore;
using EduAccess.Domain.Entities;

namespace EduAccess.Infrastructure.Context
{
    public class EduContext : DbContext
    {
        public EduContext(DbContextOptions<EduContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Student>(entity => {
                entity.ToTable("Students");
                entity.HasKey(e => e.StudentId);
            });
        }
    }
}