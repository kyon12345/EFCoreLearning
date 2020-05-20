using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EFCoreCourseTest {
    class Program {
        static void Main (string[] args) {
            var context = new EFCoreDataContext ();
            // context.Database.EnsureDeleted();
            context.Database.EnsureCreated ();

            //带有Tracking的查询
            var stopTracker = new Stopwatch();
            stopTracker.Start();

            // // var blogs = context.Blogs.ToList();
            // var blogs = context.Blogs.AsNoTracking().ToList();
            // stopTracker.Stop();

            //饥饿加载
            var blog= context.Blogs.Include(b => b.Posts).FirstOrDefault();
            // var blog = context.Blogs.AsNoTracking().Include(b => b.Posts).FirstOrDefault();

            //显式的加载,分为两次查询,性能较低
            // var blog = context.Blogs.Find(1);
            // context.Entry(blog)
            // .Collection(b => b.Posts)
            // .Load();

            //6184
            //1415
            Console.WriteLine($"花费时间为{stopTracker.ElapsedMilliseconds}");

            


            Console.ReadKey (); 
        }
    }
}