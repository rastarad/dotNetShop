using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.ModelsDto;
using Microsoft.Extensions.Configuration;

namespace Shop.Models
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
    : base(options)
        { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(15);
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .IsRequired();
            modelBuilder.Entity<CreateProductDto>().HasNoKey();
        }
        public DbSet<ProductDto> ProductDto { get; set; }
        public DbSet<CreateProductDto> CreateProductDto { get; set; }
    }
}
