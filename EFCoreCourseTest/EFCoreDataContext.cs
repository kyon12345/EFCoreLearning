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
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }


        protected override void OnConfiguring (DbContextOptionsBuilder builder) {
            builder.UseLoggerFactory(loggerFactory).
            UseSqlServer ("Server=(localdb)\\mssqllocaldb;Database=EFCoreDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating (ModelBuilder builder) {
            //一对一关系
            builder.Entity<Car>().HasOne(o => o.Driver).WithOne(o => o.Car);
            //显式的配置一对多的关系,也可以不配置，根据约定也会生成
            builder.Entity<Blog>().HasMany(o => o.Posts).WithOne(o => o.Blog).IsRequired();
            //多对多关系，配置中间表的联合主键
            builder.Entity<CourseStudent>().HasKey(p => new { p.CourseId, p.StudentId });
        }
    }
}