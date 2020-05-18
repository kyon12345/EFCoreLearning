using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EFCoreCourseTest {
    class Program {
        static void Main (string[] args) {
            var context = new EFCoreDataContext ();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated ();
            context.Employees.Add(new Employee()
            {
                FirstName = "Jeffcky",
                LastName = "Wang",
                Email = "2752154844@qq.com",
                Photo = new EmployeePhoto() { Photo = "照片" }
            });
            context.SaveChanges();

            var employees = context.Employees.Include(d => d.Photo).ToList();

            var photos = context.EmployeePhotos.ToList();
            Console.ReadKey ();
        }
    }
}