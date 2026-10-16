using EcommerceSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceSystem.Data
{
    public class EcommerceDb : DbContext
    {
        public EcommerceDb(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Relations
            modelBuilder.Entity<Category>().HasMany(c => c.products).WithOne(c => c.Category).HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany(c => c.orders).WithOne(c => c.User).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Order>().HasMany(c => c.orderItems).WithOne(c => c.Order).HasForeignKey(c => c.OrderId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>().HasMany(c => c.orderItems).WithOne(c => c.Product).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.NoAction);

            // Data Seeding

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed@example.com",
                    PasswordHash = "123456A",
                    Role = "Customer"
                },
                new User
                {
                    Id = 2,
                    FullName = "Mona Ali",
                    Email = "mona@example.com",
                    PasswordHash = "123456M",
                    Role = "Customer"
                },
                new User
                {
                    Id = 3,
                    FullName = "Store Admin",
                    Email = "admin@example.com",
                    PasswordHash = "123456Adm",
                    Role = "Admin"
                }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    Description = "Electronic devices and accessories",
                },
                new Category
                {
                    Id = 2,
                    Name = "Books",
                    Description = "Programming and technical books"
                },
                 new Category
                 {
                     Id = 3,
                     Name = "Accessories",
                     Description = "Everyday computer accessories"
                 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Wireless Mouse",
                    Price = Convert.ToDecimal(450.00), // another way is to use the m but i used this and i am glad to discover it in my own -_-
                    Description = "idk what to put in here",
                    StockQuantity = 25,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Headphones",
                    Price = 1200.00m,
                    Description = "idk what to put in here",
                    StockQuantity = 12,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "C++ Fundamentals",
                    Price = 350.00m,
                    Description = "idk what to put in here",
                    StockQuantity = 30,
                    CategoryId = 2
                }
                );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    OrderDate = new DateTime(2026 - 10 - 01),
                    Status = "Completed",
                    TotalAmount = 800.00m,
                    UserId = 1
                },
                new Order
                {
                    Id = 2,
                    OrderDate = new DateTime(2026 - 10 - 10),
                    Status = "Pending",
                    TotalAmount = 1200.00m,
                    UserId = 2
                },
                new Order
                {
                    Id = 3,
                    OrderDate = new DateTime(2026 - 10 - 12),
                    Status = "Cancelled",
                    TotalAmount = 350.00m,
                    UserId = 3
                }
                );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id = 1,
                    Quantity = 1,
                    UnitPrice = 450.00m,
                    OrderId = 1,
                    ProductId = 1
                },
                new OrderItem
                {
                    Id  = 2,
                    Quantity = 1,
                    UnitPrice = 350.00m,
                    OrderId = 2,
                    ProductId = 2
                },
                new OrderItem
                {
                    Id = 3,
                    Quantity = 1,
                    UnitPrice = 1200.00m,
                    OrderId = 3,
                    ProductId = 3
                }
                );
        }
    
    }
}
