using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace EFCoreCourseTest {
    public class EFCoreDataContext : DbContext {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder builder) {
            builder.UseSqlServer ("Server=(localdb)\\mssqllocaldb;Database=EFCoreDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating (ModelBuilder builder) 
        {
            // //局部的值转换器
            // builder.Entity<Blog>(b =>
            // {
            //     b.Property(p => p.CreatedDate).HasColumnType("DATETIME")
            //     .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
            // });
            // //全局配置
            // var dateTimeConverter = new ValueConverter<DateTime, DateTime>(v => v, v => DateTime
            // .SpecifyKind(v,DateTimeKind.Utc));

            // foreach(var entityType in builder.Model.GetEntityTypes())
            // {
            //     foreach(var property in entityType.GetProperties())
            //     {
            //         if(property.ClrType==typeof(DateTime)||property.ClrType==typeof(DateTime?))
            //             property.SetValueConverter(dateTimeConverter);
            //     }
            // }
            //值转换器练习
            builder.Entity<Blog>(b =>
            {
                b.Property(p => p.BirthDate).HasColumnType("DATETIME")
                .HasConversion(v => new DateTime(v.Year, v.Month, v.Day),
                v => new BirthDate(v.Year, v.Month, v.Day));
            });
        }
    }
}