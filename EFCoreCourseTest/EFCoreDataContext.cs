using System;
using System.Linq;
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

        protected override void OnConfiguring (DbContextOptionsBuilder builder) {
            builder.UseLoggerFactory(loggerFactory).
            UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFCoreDb;Trusted_Connection=True;");
            //使用自定义的查询
            // .ReplaceService<IQuerySqlGeneratorFactory, CustomSqlServerQuerySqlGeneratorFactory>();
        }

        protected override void OnModelCreating (ModelBuilder builder) {
           
        }
    }
}