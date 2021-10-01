using Microsoft.EntityFrameworkCore;
using pınarkuruyemis.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace pınarkuruyemis.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<Product> Products { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ProductPoolDbpınarkuruyemis;Trusted_Connection=True;");
        }
    }
}
