using System;
using System.Linq;
using Models;

namespace EFCoreCourseTest {
    class Program {
        static void Main (string[] args) {
            var context = new EFCoreDataContext ();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated ();

            // context.Blogs.Add(new Blog { Name = "smith" });

            // context.Database.EnsureCreated();

            // var blog= context.Blogs.Find(1);
            // blog.Name = "New john 2";

            // context.SaveChanges();

            context.Blogs.Add(new Blog { Name = "smith", Color = Color.Red });

            context.SaveChanges();

            var blog = context.Blogs.FirstOrDefault(b => b.Color == Color.Red);

            Console.ReadKey ();
        }
    }
}