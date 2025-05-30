using Aspiro.Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aspiro.DB.Infrastructure.BoundedContexts
{
    public class AspiroDBContext : DbContext
    {
        public AspiroDBContext(DbContextOptions<AspiroDBContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Surname).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Dni).IsRequired().HasMaxLength(10);
                entity.Property(e => e.BirthDate).IsRequired();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(10);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.Id);

                // Textos
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.AssignedTo).IsRequired();
                entity.Property(e => e.UpdatedBy);
                entity.Property(e => e.TeamAssigned).IsRequired().HasMaxLength(50);

                // Enums
                entity.Property(e => e.Priority).HasConversion<string>().HasMaxLength(20).IsRequired();
                entity.Property(e => e.Status).HasConversion<string>().HasMaxLength(20).IsRequired();

                // Fechas
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.LastUpdate);
                entity.Property(e => e.DueDate);
                entity.Property(e => e.CompletedAt);

                // Duraciones
                entity.Property(e => e.EstimatedTime);
                entity.Property(e => e.ActualTime);

            });
        }
    }
}
