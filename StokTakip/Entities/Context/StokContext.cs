using Microsoft.EntityFrameworkCore;
using StokTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Entities.Context
{
    public class StokContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=Stok.db");
            //options.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Branch>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Delivery>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Delivery>().Property(e => e.InvoiceDate);
            modelBuilder.Entity<Branch>().HasMany(I => I.Deliveries).WithOne(I => I.Branch).HasForeignKey(I => I.BranchId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>().HasMany(I => I.Deliveries).WithOne(I => I.Product).HasForeignKey(I => I.ProductId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Delivery>().HasOne(I => I.Branch).WithMany(I => I.Deliveries).HasForeignKey(I => I.BranchId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Delivery>().HasOne(I => I.Product).WithMany(I => I.Deliveries).HasForeignKey(I => I.ProductId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasData(
                new User() {Id=1, Username="mustafa",Password="123"}
                );

        }
    }
}
