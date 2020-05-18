using System;
using Models;

namespace EFCoreCourseTest {
    class Program {
        static void Main (string[] args) {
            var context = new EFCoreDataContext ();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated ();

            //只在3.0以上,插入可空的ownedType
            context.Orders.Add(new Order());

            Console.ReadKey ();
        }
    }
}