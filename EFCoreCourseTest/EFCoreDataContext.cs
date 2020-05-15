using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EFCoreCourseTest {
    public class EFCoreDataContext : DbContext {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder builder) {
            builder.UseSqlServer ("Server=(localdb)\\mssqllocaldb;Database=EFCoreDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating (ModelBuilder builder) {
            builder.Entity<Blog>().HasData(new Blog
            {
                Id = 1,
                Name = "john"
            }
            );
            builder.Entity<Blog>(b =>
            {
                b.Property(p => p.CreateDate)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()");

                // //使用计算列
                // b.Property(p => p.UpdateDate)
                // .HasColumnType("DATETIME")
                // .HasComputedColumnSql("GETDATE()");

                b.Property(p => p.UpdateDate)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()");

                // b.Property(p => p.Color).HasColumnType("TINYINT");
                //映射字符串(中文)
                // b.Property(p => p.Color).HasConversion(typeof(string)).HasMaxLength(10);
                //映射字符串
                b.Property(p => p.Color).HasColumnType("VARCHAR(20)");
            });
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().ToList();

            var updateEntires= entries.Where(e => (e.Entity is IUpdatable)
            && (e.State == EntityState.Modified)).ToList();

            updateEntires.ForEach(e =>
            {
                ((IUpdatable)e.Entity).UpdateDate = DateTime.Now;
            });

            return base.SaveChanges();
        }
    }
}