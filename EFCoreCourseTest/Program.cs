using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace EFCoreCourseTest {
    class Program {
        static void Main (string[] args) {
            var context = new EFCoreDataContext ();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated ();

            var blog = new Blog()
            {
                Name = "ef core",
                Posts = new List<Post>()
                {
                    new Post()
                    { 
                        Content = "删除操作",
                        Title = "ef core删除"
                    }
                }
            };

            context.Add(blog);

            context.SaveChanges();

            /*删除孤儿,设置依赖体的外键为空(update),删除主体(孤儿)

            //删除主体,设置外键为空
            // context.Remove(blog);

            //删除主体中的依赖体,也会完全删除依赖体
            // context.Remove(blog.Posts[0]);
            //通过主体的导航属性集合移除依赖体,设置外键为空
            blog.Posts.RemoveAt(0);

            context.SaveChanges();
            */

            //软删除的问题(before EFCore 3.0)
            blog.Posts.RemoveAt(0);

            //当然,直接更新这个栏位也是可行的
            // blog.Posts.FirstOrDefault().IsDeleted = true;

            context.SaveChanges();


            Console.ReadKey ();
        }
    }
}