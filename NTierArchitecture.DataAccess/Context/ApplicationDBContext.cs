using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.DataAccess.Context
{
    public class ApplicationDBContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=TRN00095;Initial Catalog=ETicaret;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //DB tablolarımız oluşturulurken onlara müdehale edebiliriz.

            //OrderDetail tablosunun ID alınını iptal edeceğiz:
            modelBuilder.Entity<OrderDetail>().Ignore(x=>x.Id);

            //Bunun yerine ProductID ve OrderID alanlarını Composite Key yapacağız:
            modelBuilder.Entity<OrderDetail>().HasKey(o => new {
            o.OrderID,
            o.ProductID
            });
        }
    }
}
