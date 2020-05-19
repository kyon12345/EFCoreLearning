using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Models;

namespace EFCoreCourseTest {
    public class EFCoreDataContext : DbContext {

        public EFCoreDataContext()
        {
            //默认的配置,删除的行为必须是级联的这两个设置才有效,外键不能为空
            ChangeTracker.CascadeDeleteTiming = CascadeTiming.Immediate;
            ChangeTracker.DeleteOrphansTiming = CascadeTiming.Immediate;
        }
        public static readonly ILoggerFactory loggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder builder) {
            builder.UseLoggerFactory(loggerFactory).
            UseSqlServer ("Server=(localdb)\\mssqllocaldb;Database=EFCoreDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating (ModelBuilder builder) {
            //配置级联删除,和配置外键不可空的效果一样
            // builder.Entity<Blog>().HasMany(b => b.Posts).WithOne(p => p.Blog)
            // .OnDelete(DeleteBehavior.Cascade);
        }

        //软删除
        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries())
            {
                //在3.0之前会认为post的state是modified,因为调用blog.posts.removeAt被认为是删除孤儿的操作
                switch(entry.State)
                {
                    case EntityState.Deleted:
                        ((Entity)entry.Entity).IsDeleted = true;
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }

            //当保存时发现外键不能更新为空所以直接删除了post的数据,这样软删除的目的就失败了
             return base.SaveChanges();
        }
    }
}