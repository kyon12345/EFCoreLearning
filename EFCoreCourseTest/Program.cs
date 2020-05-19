using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EFCoreCourseTest {
    class Program {
        static void Main (string[] args) {
            var context = new EFCoreDataContext ();
            // context.Database.EnsureDeleted();
            context.Database.EnsureCreated ();
            /*数据新增
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
            */


            /*数据更新*/
            // var order = new Order {StreetAddress = new StreetAddress 
            // {Street = "坂田", City = "深圳" } };

            // context.Orders.Add(order);

            /*连接的实体

            var dborder = context.Orders.SingleOrDefault(d => d.Id == 1);

            dborder.StreetAddress.Street = "新坂田";

            // if(!context.ChangeTracker.HasChanges())
            // {
            //     //对于更新操作来说影响的数据是可能为0的,所以在做异常处理的时候需要注意
            // }

            //对于未被实例化的dborder,它的状态是被跟踪的,所以这里会是true,反之,如果实例化了就是false,因为未被上下文跟踪
            var streesIsModified = context.Entry(dborder.StreetAddress).Property(p => p.Street).IsModified;*/

            var order =new Order {Id=1,StreetAddress = new StreetAddress 
            {Street = "坂田789", City = "深圳789" } };

            //使用Update方法直接更新(传染的)
            // context.Orders.Update(order);

            //使用OriginalValues,只影响自身
            //附加到上下文
            // context.Attach(order);

            // var addressEntry = context.Attach(order.StreetAddress);

            // addressEntry.OriginalValues.SetValues(addressEntry.GetDatabaseValues());


            //手动设置状态,只影响自身
            context.Attach(order);
            context.Entry(order.StreetAddress).State = EntityState.Modified;

            var result = context.SaveChanges();

            Console.ReadKey ();
        }
    }
}