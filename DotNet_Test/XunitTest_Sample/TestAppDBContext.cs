using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XunitTest_Sample
{
    public class TestAppDBContext
    {
        private readonly DbContextOptions<AppDbContext> _contextOptions;

        public AppDbContext CreateContext()
        {
            return new AppDbContext(_contextOptions);
        }

        public TestAppDBContext()
        {
            _contextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("InMemoryDB")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

            using var context = new AppDbContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.AddRange(
                new User { Id = 1, Name = "John" },
                new User { Id = 2, Name = "Jane" });

            context.SaveChanges();
        }
    }
}
