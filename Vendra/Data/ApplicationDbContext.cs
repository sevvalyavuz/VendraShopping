using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vendra.Models;

namespace Vendra.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
        public DbSet<Brand> Brands { get; set; } 
        public DbSet<Product> Products { get; set; }
        public DbSet<UserTypes> UserTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "TestMarka", LogoUrl = "/images/brand1.jpg" },
                new Brand { Id = 2, Name = "DenemeBrand", LogoUrl = "/images/brand2.jpg" }
            );


            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Test Ürün 1",
                    Description = "Bu bir test ürünüdür.",
                    ImageUrl = "/images/product1.jpg",
                    Price = 199.99m,
                    SellerId = "2",  // string
                    Color = "Kırmızı",
                    BrandId = 2
                },
                new Product
                {
                    Id = 2,
                    Name = "Test Ürün 2",
                    Description = "İkinci test ürünü.",
                    ImageUrl = "/images/product2.jpg",
                    Price = 299.50m,
                    SellerId = "1",
                    Color = "Mavi",
                    BrandId = 1
                }
            );
        }
    }


}
