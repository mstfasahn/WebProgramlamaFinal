using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Threading;
using WPF.Models.Entities;

namespace WPF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Tablolarýmýz
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. OrderDetail - Product Ýliþkisi (Sipariþ silinirse ürün silinmemeli)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(u => u.Product)
                .WithMany()
                .HasForeignKey(u => u.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // 2. City - Country Ýliþkisi
            modelBuilder.Entity<City>()
                .HasOne(u => u.Country)
                .WithMany(u => u.Cities)
                .HasForeignKey(u => u.CountryId);

            // 3. State - City Ýliþkisi
            modelBuilder.Entity<State>()
                .HasOne(u => u.City)
                .WithMany(u => u.States)
                .HasForeignKey(u => u.CityId);

            // 4. Product fiyatlarý için hassasiyet ayarý (Opsiyonel ama önerilir)

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            // OrderHeader - City iliþkisindeki Cascade silmeyi kapat
            modelBuilder.Entity<OrderHeader>()
                .HasOne(u => u.City)
                .WithMany()
                .HasForeignKey(u => u.CityId)
                .OnDelete(DeleteBehavior.NoAction); // Veya Restrict

            // OrderHeader - State iliþkisindeki Cascade silmeyi kapat
            modelBuilder.Entity<OrderHeader>()
                .HasOne(u => u.State)
                .WithMany()
                .HasForeignKey(u => u.StateId)
                .OnDelete(DeleteBehavior.NoAction);

            // OrderHeader - User iliþkisindeki Cascade silmeyi kapat
            modelBuilder.Entity<OrderHeader>()
                .HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Product ve User arasýndaki iliþkiyi yapýlandýrýyoruz
            modelBuilder.Entity<Product>()
                .HasOne(p => p.User)
                .WithMany() // Eðer User içinde ICollection<Product> varsa buraya p => p.Products yazabilirsin
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
    }
