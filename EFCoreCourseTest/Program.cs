using System;
using System.Linq;
using Models;

namespace EFCoreCourseTest {
    class Program {
        static void Main (string[] args) {
            var context = new EFCoreDataContext ();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated ();

            context.Blogs.Add(new Blog
            {
                Name = "john",
                BirthDate = new BirthDate(1995, 1, 28)
            });

            context.SaveChanges();

            foreach(var blog in context.Blogs.ToList())
            {
                Console.WriteLine($"下次生日{blog.BirthDate.DaysOfNextBirthDay()}");
            }

            Console.ReadKey ();
        }
    }
}