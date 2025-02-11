using Aspiro.Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aspiro.DB.Infrastructure.BoundedContexts
{
    public class AspiroDBContext : DbContext
    {
        public AspiroDBContext(DbContextOptions<AspiroDBContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

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
        }
    }
}
