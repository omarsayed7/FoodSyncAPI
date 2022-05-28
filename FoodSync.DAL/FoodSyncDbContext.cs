using FoodSync.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace FoodSync.DAL
{
    public class FoodSyncDbContext : DbContext
    {
        public FoodSyncDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            string connectionString = root.GetSection("ConnectionStrings").GetSection("DbConnection").Value;

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }

        }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<DailyOperation> DailyOperations { get; set; }
        public virtual DbSet<OpenningClosingQty> OpenningClosingQties { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RawMaterial> RawMaterials { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ProductSale> ProductSales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RawMaterial>()
                .HasMany<ProductRawMaterial>(s => s.productRawMaterials)
                .WithOne(c => c.RawMaterial)
                .HasForeignKey(x => x.RawMaterialId);

            modelBuilder.Entity<Product>()
                .HasMany<ProductRawMaterial>(s => s.ProductRawMaterials)
                .WithOne(c => c.Product)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<Product>()
               .HasMany<ProductSale>(s => s.ProductSales)
               .WithOne(c => c.Product)
               .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<Sale>()
                .HasMany<ProductSale>(s => s.ProductSales)
                .WithOne(c => c.Sale)
                .HasForeignKey(x => x.SaleId);
        }
    }
}