using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using EcommerceApp.DatabaseContext.FluentConfiguration;
using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.DatabaseContext
{
    public class EcommerceDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies(false)
                .UseSqlServer("Server=(local);Database=EcommerceDb4; Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductFluentConfiguration());
            modelBuilder.Entity<ProductOrder>().HasKey(c => new {c.ProductId, c.OrderId});

            modelBuilder.Entity<ProductOrder>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(pt => pt.Order)
                .WithMany(t => t.Products)
                .HasForeignKey(pt => pt.OrderId);
        }

    
    }
}
