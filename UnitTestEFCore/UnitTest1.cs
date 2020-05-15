using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace UnitTestEFCore {
    public class EFCoreDbContext : DbContext {
        public EFCoreDbContext (DbContextOptions options) : base (options) { }
        public DbSet<Blog> Blogs { get; set; }
    }

    [TestClass]
    public class UnitTest1 {
        public static DbContextOptions<EFCoreDbContext> CreateDbContextOptions (string databaseName) {
            var serviceProvider = new ServiceCollection ()
                .AddEntityFrameworkInMemoryDatabase ()
                .BuildServiceProvider ();

            var builder = new DbContextOptionsBuilder<EFCoreDbContext> ();

            builder.UseInMemoryDatabase (databaseName)
                .UseInternalServiceProvider (serviceProvider);

            return builder.Options;
        }

        [TestMethod]
        public void TestMethod1 () {
            var options = CreateDbContextOptions ("database");
            var context = new EFCoreDbContext (options);

            context.Blogs.Add (new Blog { Name = "john" });

            context.SaveChanges ();

            var blog = context.Blogs.FirstOrDefaultAsync (d => d.Id == 1);

            Assert.IsNotNull (blog);
        }
    }
}