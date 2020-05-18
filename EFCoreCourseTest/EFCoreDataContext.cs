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

                //值转换器,加密和解密密码字段
                b.Property(p => p.Password).HasConversion(v => Encyrpt(v),v=>Decyrpt(v));

                //内置的值转换器,默认的转化false为0,true为1
                // b.Property(i => i.IsMine).HasMaxLength(1).IsUnicode(false).HasConversion(typeof(string));

                //自定义的值转换器
                var boolConverter = new ValueConverter<bool, string>(v => v ? "X" : "", v => v == "X");
                b.Property(i => i.IsMine).HasMaxLength(1).IsUnicode(false).HasConversion(boolConverter);

            });
        }

        string Encyrpt(string Password)
        {
            return String.Empty;
        }

        string Decyrpt(string Password)
        {
            return String.Empty;
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