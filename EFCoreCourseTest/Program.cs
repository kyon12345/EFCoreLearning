using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EFCoreCourseTest {
    class Program {
        static void Main (string[] args) {
            var context = new EFCoreDataContext ();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated ();
            
            //对于显示指定Id的数据重写savechange方法指定Id为0
            var order = new Order {Id=5, StreetAddress = new StreetAddress 
            {Street = "坂田", City = "深圳" } };

            // //方法的调用具有传染性
            context.Orders.Add(order);

            // //手动的设置,不会添加导航属性,只会影响调用者本身
            // // context.Entry(order).State = EntityState.Added;

            // context.SaveChanges();

            // context.Attach(order);

            // //Added
            // Console.WriteLine(context.Entry(order).State.ToString());

            var result = context.SaveChanges();

            Console.ReadKey ();
        }
    }
}