using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EFCoreCourseTest {
    public class EFCoreDataContext : DbContext {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<EmployeePhoto> EmployeePhotos { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder builder) {
            builder.UseSqlServer ("Server=(localdb)\\mssqllocaldb;Database=EFCoreDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating (ModelBuilder builder) {
            builder.Entity<Employee>().HasOne(e => e.Photo).WithOne(p => p.Employee)
            .HasForeignKey<EmployeePhoto>(k => k.Id);
        }
    }
}