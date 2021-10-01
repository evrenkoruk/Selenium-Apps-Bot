using Microsoft.EntityFrameworkCore;
using karadagbaharat.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace  karadagbaharat.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<ProductAddress> ProductAddresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Barcode> Barcode { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ProductPoolDbkaradagbaharat;Trusted_Connection=True;");
        }
    }
}
