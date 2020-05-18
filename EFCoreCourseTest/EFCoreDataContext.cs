using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EFCoreCourseTest {
    public class EFCoreDataContext : DbContext {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder builder) {
            builder.UseSqlServer ("Server=(localdb)\\mssqllocaldb;Database=EFCoreDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating (ModelBuilder builder) {
            //     //简单的自类型
            //     builder.Entity<Order>().OwnsOne(p => p.ShippingAddress);
            //     //映射为单独的表,主键变为Order表的外键
            //     builder.Entity<Order>().OwnsOne(p => p.ShippingAddress).ToTable("ShippingAddress");
            ////电商模型练习
            builder.Entity<DetailedOrder>().OwnsOne(p => p.OrderDetails, od =>
            {
                od.OwnsOne(c => c.BillingAddress);
                od.OwnsOne(c => c.ShippingAddress);

                od.ToTable("OrderDetails");

                //在3.0版本的EF中需要规定为非自然增长的主键
                // od.Property("OrderDetailId").ValueGeneratedNever();
            });
        }
    }
}