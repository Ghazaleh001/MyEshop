using Microsoft.EntityFrameworkCore;
using MyEshop.Models;

namespace MyEshop.Data
{
    public class MyEshopContext : DbContext
    {
        public MyEshopContext(DbContextOptions<MyEshopContext> options):  base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>()
                .HasKey(t => new { t.ProductId, t.CategoryId });

            //modelBuilder.Entity<Product>(
            //    p => 
            //    {
            //        p.HasKey(w => w.Id);
            //        p.OwnsOne<Item>(w => w.Item);
            //        p.HasOne<Item>(w => w.Item).WithOne(w => w.Product).HasForeignKey<Item>(w => w.Id);

            //    }
          
            //    );

            modelBuilder.Entity<Item>(
                i =>
                {
                    i.Property(w => w.Price).HasColumnType("Money");
                    i.HasKey(w => w.Id);
                }
                );

            #region Seed Data 

            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 1,
                Name = "Asp.Net Core",
                Description = "Asp.Net Core 9"

            },
            new Category()
            {
                Id = 2,
                Name = "لباس ورزشی ",
                Description = "گروه لباس ورزشی"

            },
            new Category()
            {
                Id = 3,
                Name = "ساعت مچی",
                Description = "ساعت مچی"

            },
            new Category()
            {
                Id = 4,
                Name = "لوازم منزل",
                Description = "لوازم منزل"

            }

           
                );
            modelBuilder.Entity<Item>().HasData(
            new Item()
            {
                Id = 1,
                Price = 854.0M,
                QuantityInStock = 5

            },
            new Item()
            {
                Id = 2,
                Price = 3302.0M,
                QuantityInStock = 8

            },
            new Item()
            {
                Id = 3,
                Price = 2500 ,
                QuantityInStock = 3

            }
            );
            modelBuilder.Entity<Product>().HasData(
            new Product()
            {
                Id = 1,
                Name = "ASP.Net",
                Description = "this is asp.net course" ,
                ItemId = 1

            },
            new Product()
            {
                Id = 2,
                Name = "Python" ,
                Description = "this is python course",
                ItemId = 2

            },
            new Product()
            {
                Id = 3,
                Name = "Java",
                Description = "this is Java course",
                ItemId = 3

            }
            );
            modelBuilder.Entity<CategoryToProduct>().HasData(
                 new CategoryToProduct() { CategoryId = 1, ProductId = 1 },
                 new CategoryToProduct() { CategoryId = 2, ProductId = 1 },
                 new CategoryToProduct() { CategoryId = 3, ProductId = 1 },
                 new CategoryToProduct() { CategoryId = 4, ProductId = 1 },
                 new CategoryToProduct() { CategoryId = 1, ProductId = 2 },
                 new CategoryToProduct() { CategoryId = 2, ProductId = 2 },
                 new CategoryToProduct() { CategoryId = 3, ProductId = 2 },
                 new CategoryToProduct() { CategoryId = 4, ProductId = 2 },
                 new CategoryToProduct() { CategoryId = 1, ProductId = 3 },
                 new CategoryToProduct() { CategoryId = 2, ProductId = 3 },
                 new CategoryToProduct() { CategoryId = 3, ProductId = 3 },
                 new CategoryToProduct() { CategoryId = 4, ProductId = 3 }

                );

            #endregion
           base.OnModelCreating(modelBuilder);
        }
    }
}
