using DbWriter.DbAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DbWriter.DbAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Products);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithMany(p => p.Orders)
                .UsingEntity<OrderProduct>();

            Product p1 = new() { Id = 1, Name = "LG 1755", Price = 12000.75, Quantity = 100 };
            Product p2 = new() { Id = 2, Name = "Xiomi 12X", Price = 42000.75, Quantity = 100 };
            Product p3 = new() { Id = 3, Name = "Noname 14232", Price = 1.7, Quantity = 100 };
            Product p4 = new() { Id = 4, Name = "Noname 222", Price = 3.14, Quantity = 100 };

            modelBuilder.Entity<Product>().HasData(p1, p2, p3, p4);
        }
    }
}
