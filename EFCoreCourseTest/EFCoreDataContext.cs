using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Logging;
using Models;

namespace EFCoreCourseTest {
    public class EFCoreDataContext : DbContext {
        public static readonly ILoggerFactory loggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<BlogDto> BlogDtos{ get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder builder) {
            builder.UseLoggerFactory(loggerFactory).
            UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFCoreDb;Trusted_Connection=True;");
            //使用自定义的查询
            // .ReplaceService<IQuerySqlGeneratorFactory, CustomSqlServerQuerySqlGeneratorFactory>();
        }

        protected override void OnModelCreating (ModelBuilder builder) {
            //对应数据库中的视图
            // builder.Entity<BlogDto>().HasNoKey().ToView("Blog_Names");
            //使用lamda表达式
            builder.Entity<BlogDto>().HasNoKey().ToQuery(() => Blogs.Select(b => new BlogDto()
            {
                Name = b.Name
            }));

            //针对比较复杂的使用expression
            // Expression<Func<IQueryable<BlogDto>>> query()
            // {

            // }
        }
    }
}