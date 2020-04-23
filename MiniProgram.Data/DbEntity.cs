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
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderItemCategory> OrderItemCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<Order>().ToTable("order");
            modelBuilder.Entity<OrderItem>().ToTable("order_item");
            modelBuilder.Entity<OrderItemCategory>().ToTable("order_item_category");


            modelBuilder.Entity<User>().HasMany(p => p.PrepayOrders).WithOne(p => p.Prepayer)
                .HasForeignKey(p => p.PrepayerId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany(p => p.ConsumeOrderItems).WithOne(p => p.Consumer)
                .HasForeignKey(p => p.ConsumerId).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Order>().HasOne(p => p.Prepayer).WithMany(p => p.PrepayOrders)
                .HasForeignKey(p => p.PrepayerId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Order>().HasMany(p => p.OrderItems).WithOne(p => p.Order)
                .HasForeignKey(p => p.OrderId).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<OrderItem>().HasOne(p => p.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(p => p.OrderId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<OrderItem>().HasOne(p => p.Consumer).WithMany(p => p.ConsumeOrderItems)
                .HasForeignKey(p => p.ConsumerId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<OrderItem>().HasOne(p => p.OrderItemCategory).WithMany(p => p.OrderItems)
                .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
