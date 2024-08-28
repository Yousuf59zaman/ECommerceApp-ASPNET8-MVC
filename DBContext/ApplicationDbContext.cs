using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using ECommerceApp.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ECommerceApp.Models;
namespace ECommerceApp.DBContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for other tables (e.g., Products, Orders, etc.)
        // DbSets for Products and Categories
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        // DbSets for new tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define GUIDs for seeding
            var electronicsCategoryId = Guid.NewGuid();
            var homeAppliancesCategoryId = Guid.NewGuid();

            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = electronicsCategoryId,
                    CategoryType = "Electronics",
                    CategoryName = "Mobile Phones"
                },
                new Category
                {
                    CategoryId = homeAppliancesCategoryId,
                    CategoryType = "Home Appliances",
                    CategoryName = "Refrigerators"
                }
            );

            // Seed data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "iPhone 13",
                    ProductDesc = "Latest Apple iPhone 13 with A15 Bionic chip.",
                    ProductUnitPrice = 999,
                    ProductImage = "iphone13.jpg",
                    CategoryId = electronicsCategoryId
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Samsung Galaxy S21",
                    ProductDesc = "Samsung Galaxy S21 with Exynos 2100.",
                    ProductUnitPrice = 799,
                    ProductImage = "galaxys21.jpg",
                    CategoryId = electronicsCategoryId
                }
            );
        }
    }







    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
