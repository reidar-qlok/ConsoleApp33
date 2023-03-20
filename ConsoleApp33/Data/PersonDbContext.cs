using ConsoleApp33.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp33.Data
{
    public class PersonDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderList> OrderLists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=REIDAR10PRO\\SQL2K19; Initial Catalog=MobilePhoneDB;Integrated Security=true");

            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderList>()
                .HasOne(p => p.Products)
                .WithMany(p => p.OrderLists)
                .HasForeignKey(pl => pl.FkProductId);
            modelBuilder.Entity<OrderList>()
                .HasOne(p => p.Persons)
                .WithMany(p => p.OrderLists)
                .HasForeignKey(pl => pl.FkPersonId);
        }
    }
}
