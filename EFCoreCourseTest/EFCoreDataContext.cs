using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace EFCoreCourseTest {
    public class EFCoreDataContext : DbContext {
        public static readonly ILoggerFactory loggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Order> Orders{ get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder builder) {
            builder.UseLoggerFactory(loggerFactory).
            UseSqlServer ("Server=(localdb)\\mssqllocaldb;Database=EFCoreDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating (ModelBuilder builder) {
            builder.Entity<Order>().OwnsOne(o => o.StreetAddress);
        }

        // public override int SaveChanges()
        // {
        //     foreach(var entry in ChangeTracker.Entries())
        //     {
        //         if(entry.Entity is Entity && entry.State == EntityState.Added&&entry.IsKeySet)
        //         {
        //             ((Entity)entry.Entity).Id = 0;
        //         }
        //     }

        //     return base.SaveChanges();
        // }
    }
}