using System;
using Models;

namespace EFCoreCourseTest {
    class Program {
        static void Main (string[] args) {
            var context = new EFCoreDataContext ();
            context.Database.EnsureCreated ();

            // context.Blogs.Add(new Blog { Name = "smith" });

            // context.Database.EnsureCreated();

            // var blog= context.Blogs.Find(1);
            // blog.Name = "New john 2";
            
            context.SaveChanges();

            Console.ReadKey ();
        }
    }
}