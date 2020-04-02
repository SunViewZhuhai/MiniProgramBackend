using Microsoft.EntityFrameworkCore;
using MiniProgram.Data.Model;

namespace MiniProgram.Data
{
    public class DbEntity : DbContext
    {
        public DbEntity(DbContextOptions<DbEntity> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CostCategory> CostCategories { get; set; }
        public DbSet<Cost> Costs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<User>().HasMany(p => p.Costs).WithOne(p => p.User).HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CostCategory>().ToTable("cost_category");

            modelBuilder.Entity<Cost>().ToTable("cost");
            modelBuilder.Entity<Cost>().HasOne(p => p.User).WithMany(p => p.Costs).HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Cost>().HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
